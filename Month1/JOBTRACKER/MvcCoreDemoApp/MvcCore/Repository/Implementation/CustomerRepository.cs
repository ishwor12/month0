using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;

namespace MvcCore.Repository.Implementation
{
    public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Customer?> GetByEmailAsync(string email)
        => await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);

        public async Task<Customer?> GetCustomerWithOrdersAsync(int id)
         => await _context.Customers
                .Include(c => c.SalesOrders)
                    .ThenInclude(o => o.Items)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async  Task<IEnumerable<Customer>> SearchAsync(string keyword)
         => await _context.Customers
                .Where(c => c.Name.Contains(keyword) ||
                            c.Email.Contains(keyword))
                .ToListAsync();

    }
}
