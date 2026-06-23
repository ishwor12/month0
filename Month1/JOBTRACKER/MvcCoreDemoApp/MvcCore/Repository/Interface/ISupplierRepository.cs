using MvcCore.Models;
using MvcCore.Models.Enums;

namespace MvcCore.Repository.Interface
{
    public interface ISupplierRepository:IGenericRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> SearchAsync(string keyword);
        Task<Supplier?> GetSupplierWithProductsAsync(int id);

    }
}
