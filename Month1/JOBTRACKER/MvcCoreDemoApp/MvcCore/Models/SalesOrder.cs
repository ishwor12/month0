using MvcCore.Models.Enums;

namespace MvcCore.Models
{
   
    public class SalesOrder
    {
        
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public Customer Customer { get; set; } = null!;
        public ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();

    }
}
