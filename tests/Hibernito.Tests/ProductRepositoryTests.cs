using Hibernito.Domain;
using Hibernito.Repository;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Hibernito.Tests
{
    public class ProductRepositoryTests : IClassFixture<RepositoryFixture>
    {
        private readonly RepositoryFixture _fixture;
        private readonly IProductRepository _target;

        private readonly Product[] _products =
        [
            new Product("Melon", "Fruits"),
            new Product("Pear", "Fruits"),
            new Product("Milk", "Beverages"),
            new Product("Coca Cola", "Beverages"),
            new Product("Pepsi Cola", "Beverages"),
        ];

        public ProductRepositoryTests(RepositoryFixture fixture)
        {
            _fixture = fixture;
            _target = new ProductRepository();

            CreateSchema();
            CreateInitialSeeding();
        }

        private void CreateSchema()
        {
            new SchemaExport(_fixture.Cfg).Execute(false, true, false);
        }

        private void CreateInitialSeeding()
        {
            using ISession session = _fixture.SessionFactory.OpenSession();
            using ITransaction transaction = session.BeginTransaction();

            foreach (var product in _products)
                session.Save(product);

            transaction.Commit();
        }

        [Fact]
        public void Add_ShouldPersistOnDatabase_WhenProductIsProvided()
        {
            var product = new Product("Apple", "Fruits");
            
            _target.Add(product);

            using ISession session = _fixture.SessionFactory.OpenSession();
            var fromDb = session.Get<Product>(product.Id);

            Assert.NotNull(fromDb);
            Assert.Equal(product.Id, fromDb.Id);
            Assert.Equal(product.Name, fromDb.Name);
        }

        [Fact]
        public void Update_ShouldUpdateEntity_WhenSomePropChanges()
        {
            var product = _products[0];
            product.Name = "Yellow Pear";

            _target.Update(product);

            using ISession session = _fixture.SessionFactory.OpenSession();
            var fromDb = session.Get<Product>(product.Id);

            Assert.Equal(product.Name, fromDb.Name);
        }

        [Fact]
        public void Delete_ShouldRemoveEntity_WhenExistsInDatabase()
        {
            var product = _products[0];

            _target.Remove(product);

            using ISession session = _fixture.SessionFactory.OpenSession();
            var fromDb = session.Get<Product>(product.Id);

            Assert.Null(fromDb);
        }

        [Fact]
        public void GetById_ShouldReturnEntity_WhenIdEqualToParam()
        {
            var product = _target.GetById(_products[1].Id);

            Assert.NotNull(product);
            Assert.Equal(product.Id, _products[1].Id);
        }

        [Fact]
        public void GetByName_ShouldReturnEntity_WhenNameEqualToParam()
        {
            var product = _target.GetByName(_products[2].Name);

            Assert.NotNull(product);
            Assert.Equal(product.Name, _products[2].Name);
        }

        [Fact]
        public void GetByCategory_ShouldReturnCollectionOfEntities_WhenCategoryEqualToParam()
        {
            var products = _target.GetByCategory("Beverages");

            Assert.Equal(3, products.Count);
            Assert.True(IsInCollection(_products[2], products));
            Assert.True(IsInCollection(_products[3], products));
            Assert.True(IsInCollection(_products[4], products));
        }

        private bool IsInCollection(Product product, ICollection<Product> fromDb)
        {
            return fromDb.Any(f => f.Id == product.Id);
        }
    }
}
