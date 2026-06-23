using MvcCore.Models;

namespace MvcCore.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> GetProductWithDetailsAsync(int id);
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
        Task<IEnumerable<Product>> SearchProductsAsync(string keyword);
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<bool> IsSkuUniqueAsync(string sku);
    }
}
