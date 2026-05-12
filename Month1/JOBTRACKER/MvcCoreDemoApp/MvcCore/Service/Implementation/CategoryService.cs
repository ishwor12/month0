using MvcCore.Data;
using MvcCore.Models;
using MvcCore.Repository.Interface;
using MvcCore.Service.Interface;

namespace MvcCore.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly ApplicationDbContext _context;

        public CategoryService(IGenericRepository<Category> categoryRepo, ApplicationDbContext context)
        {
            _categoryRepo = categoryRepo;
            _context = context;
        }
        public async Task CreateAsync(Category category)
        {
            // name can't be empty
        if (string.IsNullOrWhiteSpace(category.Name))
                throw new InvalidOperationException("Category name is required.");

            await _categoryRepo.AddAsync(category);
            await _context.SaveChangesAsync();
        
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
         => await _categoryRepo.GetAllAsync();

        public async Task<Category?> GetByIdAsync(int id)
          => await _categoryRepo.GetByIdAsync(id);

        public async  Task UpdateAsync(Category category)
        {
            var existing = await _categoryRepo.GetByIdAsync(category.Id)
           ?? throw new KeyNotFoundException($"Category {category.Id} not found.");

            _categoryRepo.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
