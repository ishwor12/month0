using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Service.Implementation
{
    public class SupplierService:ISupplierService
    {
        private readonly ISupplierRepository _supplierRepo;
        private readonly ApplicationDbContext _context;
        public SupplierService(ISupplierRepository supplierRepo, ApplicationDbContext context)
        {
            _supplierRepo = supplierRepo;
            _context = context;
        }

        public async Task CreateAsync(Supplier supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.Name))
                throw new InvalidOperationException("Supplier is required.");

            await _supplierRepo.AddAsync(supplier);
            await _context.SaveChangesAsync();

        }

        public async  Task DeleteAsync(int id)
        {
            var supplier = await _supplierRepo.GetSupplierWithProductsAsync(id)
                ?? throw new KeyNotFoundException($"Supplier {id} not found.");

            if (supplier.Products.Any())
                throw new InvalidOperationException(
                    $"Cannot delete '{supplier.Name}' — " +
                    $"it has {supplier.Products.Count} product(s) assigned. " +
                    $"Reassign or remove products first.");

            _supplierRepo.Delete(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
       => await _supplierRepo.GetAllAsync();

        public async Task<Supplier?> GetByIdAsync(int Id)
       => await _supplierRepo.GetByIdAsync(Id);

        public async Task<Supplier?> GetSupplierWithProductsAsync(int id)
         => await _supplierRepo.GetSupplierWithProductsAsync(id);


        public async Task<IEnumerable<Supplier>> SearchAsync(string keyword)
           => await _supplierRepo.SearchAsync(keyword);


        public async Task UpdateAsync(Supplier supplier)
        {
            var existing = await _supplierRepo.GetByIdAsync(supplier.Id)
                ?? throw new KeyNotFoundException($"Supplier {supplier.Id} not found.");

            _supplierRepo.Update(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
