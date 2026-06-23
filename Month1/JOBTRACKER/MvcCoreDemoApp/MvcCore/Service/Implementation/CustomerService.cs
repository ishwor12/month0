using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly ApplicationDbContext _context;

        public CustomerService(ICustomerRepository customerRepo, ApplicationDbContext context)
        {
            _customerRepo = customerRepo;
            _context = context;

        }

        public async Task CreateAsync(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new InvalidOperationException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(customer.Email) ||
                !customer.Email.Contains('@'))
                throw new InvalidOperationException("A valid email is required.");

            var existing = await _customerRepo.GetByEmailAsync(customer.Email);
            if (existing != null)
                throw new InvalidOperationException(
                    $"A customer with email '{customer.Email}' already exists.");

            await _customerRepo.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _customerRepo.GetCustomerWithOrdersAsync(id)
                ?? throw new KeyNotFoundException($"Customer {id} not found.");

            if (customer.SalesOrders.Any())
                throw new InvalidOperationException(
                    $"Cannot delete '{customer.Name}' — " +
                    $"they have {customer.SalesOrders.Count} order(s) on record.");

            _customerRepo.Delete(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        => await _customerRepo.GetAllAsync();

        public async Task<Customer?> GetByIdAsync(int id)
         => await _customerRepo.GetByIdAsync(id);

        public async Task<Customer?> GetCustomerWithOrdersAsync(int id)
          => await _customerRepo.GetCustomerWithOrdersAsync(id);


        public async Task<IEnumerable<Customer>> SearchAsync(string keyword)
          => await _customerRepo.SearchAsync(keyword);


        public async Task UpdateAsync(Customer customer)
        {
            var existing = await _customerRepo.GetByIdAsync(customer.Id)
               ?? throw new KeyNotFoundException($"Customer {customer.Id} not found.");

            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new InvalidOperationException("Customer name is required.");

            if (string.IsNullOrWhiteSpace(customer.Email) ||
                !customer.Email.Contains('@'))
                throw new InvalidOperationException("A valid email is required.");

            var emailOwner = await _customerRepo.GetByEmailAsync(customer.Email);
            if (emailOwner != null && emailOwner.Id != customer.Id)
                throw new InvalidOperationException(
                    $"Email '{customer.Email}' is already used by another customer.");

            _customerRepo.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
