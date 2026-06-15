using Microsoft.EntityFrameworkCore;
using MvcCore.Data;
using MvcCore.Repository.Interface;

namespace MvcCore.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); 
            // could have skip it
            // works fine ,, // almost 0 benefit // just to fallow clean code n dry principle
            // if not initialized here every time has to do .Set<T>() 
            //await _context.Set<T>().FindAsync(id); in every action.
        }
        public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

        public void Delete(T entity)
       => _dbSet.Remove(entity);

        public async  Task<IEnumerable<T>> GetAllAsync()
      => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
           => await _dbSet.FindAsync(id);

        public void Update(T entity)
        => _dbSet.Update(entity);
    }
}
