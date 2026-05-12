using System.ComponentModel.DataAnnotations;

namespace MvcCore.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string SKU { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int StockQty { get; set; }

        public int LowStockThreshold { get; set; } = 10;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        // For displaying in views
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
        public bool IsLowStock => StockQty <= LowStockThreshold;
    
}
}
