using MvcCore.Models;

namespace MvcCore.Service.Interface
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetCustomerWithOrdersAsync(int id);
        Task<IEnumerable<Customer>> SearchAsync(string keyword);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}
