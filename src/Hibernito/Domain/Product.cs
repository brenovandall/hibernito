namespace Hibernito.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool Discontinued { get; set; }
    }
}
