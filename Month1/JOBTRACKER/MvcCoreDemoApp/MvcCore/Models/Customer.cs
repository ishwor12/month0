 namespace MvcCore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

    }
}
