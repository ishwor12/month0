using MvcCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string StatusBadge => Status switch
        {
            OrderStatus.Pending => "warning",
            OrderStatus.Confirmed => "success",
            OrderStatus.Cancelled => "danger",
            _ => "secondary"
        };

        [Required]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public List<OrderItemViewModel> Items { get; set; } = new();
        public decimal OrderTotal => Items.Sum(i => i.LineTotal);
    }
}
