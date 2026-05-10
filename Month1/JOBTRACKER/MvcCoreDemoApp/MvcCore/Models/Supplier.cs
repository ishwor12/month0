namespace MvcCore.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public string? Email { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
