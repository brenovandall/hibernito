namespace Hibernito.Domain
{
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; } = default!;
        public virtual string Category { get; set; } = default!;
        public virtual bool Discontinued { get; set; }

        public Product() { }

        public Product(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }
}
