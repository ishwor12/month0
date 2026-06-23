using MvcCore.Models;

namespace MvcCore.Repository.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> SearchAsync(string keyword);
        Task<Customer?> GetCustomerWithOrdersAsync(int id);
        Task<Customer?> GetByEmailAsync(string email);
    }
}
