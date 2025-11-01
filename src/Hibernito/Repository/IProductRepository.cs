using Hibernito.Domain;

namespace Hibernito.Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        Product GetById(Guid id);
        Product GetByName(string name);
        ICollection<Product> GetByCategory(string category);
    }
}
