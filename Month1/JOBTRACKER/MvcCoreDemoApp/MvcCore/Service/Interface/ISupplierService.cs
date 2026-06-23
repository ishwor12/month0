using MvcCore.Models;

namespace MvcCore.Service.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier?> GetByIdAsync(int Id);
        Task<Supplier?> GetSupplierWithProductsAsync(int id);
        Task<IEnumerable<Supplier>> SearchAsync(string keyword);
        Task CreateAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
    }
}
