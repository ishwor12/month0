using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;

namespace MvcCore.Repository.Implementation
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Supplier?> GetSupplierWithProductsAsync(int id)
         => await _context.Suppliers
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<IEnumerable<Supplier>> SearchAsync(string keyword)
        => await _context.Suppliers
                .Where(s => s.Name.Contains(keyword) ||
                            (s.ContactName != null && s.ContactName.Contains(keyword)) ||
                            (s.Email != null && s.Email.Contains(keyword)))
                .ToListAsync();

    }
}
