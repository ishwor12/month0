namespace MvcCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public int LowStockThreshold { get; set; } = 10;
        public bool IsActive { get; set; } = true;
        // FK
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        // Navigation
        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
        public ICollection<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();


    }
}
