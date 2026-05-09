using MvcCore.Models;

namespace MvcCore.Repository.Interface
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetLowStockProductsAsync();
        Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId);
        Task<Product?> GetBySkuAsync(string sku);
        Task<IEnumerable<Product>> SearchAsync(string keyword);
    }
}
