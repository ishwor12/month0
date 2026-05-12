using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }
}
