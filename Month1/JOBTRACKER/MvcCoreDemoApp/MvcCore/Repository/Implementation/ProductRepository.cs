using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;

namespace MvcCore.Repository.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        => await _context.Products.Where
        (p => p.CategoryId == categoryId && p.IsActive)
        .Include(p => p.Category)
        .Include(p => p.Supplier).ToListAsync();

        public async Task<Product?> GetBySkuAsync(string sku)
        => await _context.Products.FirstOrDefaultAsync(p => p.SKU == sku);

        public async Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId)
        => await _context.Products.Where(p => p.SupplierId == supplierId && p.IsActive)
            .Include(p => p.Supplier)
            .ToListAsync();

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync()
        => await _context.Products.Where(p => p.StockQty <= p.LowStockThreshold && p.IsActive)
            .Include(s => s.Category)
        .ToListAsync();

        public async Task<IEnumerable<Product>> SearchAsync(string keyword)
        => await _context.Products.Where
        (p => p.Name.Contains(keyword) || p.SKU.Contains(keyword))
        .Include(p => p.Category).ToListAsync();
    }
}
