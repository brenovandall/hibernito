namespace Habernito.Api.Domain
{
    public class Product
    {
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool Discontinued { get; set; }
    }
}
