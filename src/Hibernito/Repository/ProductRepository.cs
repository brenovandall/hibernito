using Hibernito.Domain;
using Hibernito.Helpers;
using NHibernate;
using NHibernate.Criterion;

namespace Hibernito.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
            using ISession session = NHibernateHelper.OpenSession();
            using ITransaction transaction = session.BeginTransaction();
            session.Save(product);
            transaction.Commit();
        }

        public void Update(Product product)
        {
            using ISession session = NHibernateHelper.OpenSession();
            using ITransaction transaction = session.BeginTransaction();
            session.Update(product);
            transaction.Commit();
        }

        public void Remove(Product product)
        {
            using ISession session = NHibernateHelper.OpenSession();
            using ITransaction transaction = session.BeginTransaction();
            session.Delete(product);
            transaction.Commit();
        }

        public Product GetById(Guid id)
        {
            using ISession session = NHibernateHelper.OpenSession();
            return session.Get<Product>(id);
        }

        public Product GetByName(string name)
        {
            using ISession session = NHibernateHelper.OpenSession();
            var criteria = session.CreateCriteria(typeof(Product))
                .Add(Restrictions.Eq(nameof(Product.Name), name));

            return criteria.UniqueResult<Product>();
        }

        public ICollection<Product> GetByCategory(string category)
        {
            using ISession session = NHibernateHelper.OpenSession();
            var criteria = session.CreateCriteria(typeof(Product))
                .Add(Restrictions.Eq(nameof(Product.Category), category));

            return criteria.List<Product>();
        }

        private ICollection<Product> Sample1(string category)
        {
            using ISession session = NHibernateHelper.OpenSession();
            return [.. session.Query<Product>().Where(p => p.Category == category)];
        }
    }
}
