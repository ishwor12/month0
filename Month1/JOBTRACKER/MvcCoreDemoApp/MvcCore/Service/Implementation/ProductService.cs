using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ApplicationDbContext _context;

        public ProductService(IProductRepository productRepo, ApplicationDbContext context)
        {
            _productRepo = productRepo;
            _context = context;

        }
        public async Task CreateProductAsync(Product product)
        {
            var SkuExists = await _productRepo.GetBySkuAsync(product.SKU);
              if (SkuExists != null)
                throw new InvalidOperationException($"SKU '{product.SKU}' already exists.");

            if (product.Price < 0)
                throw new InvalidOperationException("Price cannot be negative.");

            if (product.StockQty < 0)
                throw new InvalidOperationException("Stock quantity cannot be negative.");

            await _productRepo.AddAsync(product);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id)
           ?? throw new KeyNotFoundException($"Product {id} not found.");
            // just a soft delete
            product.IsActive = false;
            _productRepo.Update(product);
            await _context.SaveChangesAsync();

        }
        public async Task<Product?> GetProductWithDetailsAsync(int id)
        => await _productRepo.GetProductWithDetailsAsync(id);

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        => await _productRepo.GetAllAsync();

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
         => await _productRepo.GetByCategoryAsync(categoryId);

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync()
         => await _productRepo.GetLowStockProductsAsync();

        public async Task<Product?> GetProductByIdAsync(int id)
         => await _productRepo.GetByIdAsync(id);

        public async Task<bool> IsSkuUniqueAsync(string sku)
        => await _productRepo.GetBySkuAsync(sku) == null;

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
          => await _productRepo.SearchAsync(keyword);

        public async Task UpdateProductAsync(Product product)
        {
            var existing = await _productRepo.GetByIdAsync(product.Id)
             ?? throw new KeyNotFoundException($"Product {product.Id} not found.");

            if (product.Price < 0)
                throw new InvalidOperationException("Price cannot be negative.");
            _productRepo.Update(product);
            await _context.SaveChangesAsync();

        }
    }
}
