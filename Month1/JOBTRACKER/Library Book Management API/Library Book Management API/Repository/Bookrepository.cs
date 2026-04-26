using Library_Book_Management_API.Data;
using Library_Book_Management_API.Models;
using Library_Book_Management_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library_Book_Management_API.Repository
{
    public class Bookrepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public Bookrepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddAsync(Book book)
        {
           _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<Book?> DeleteAsync(int id)
        {
            var bookies = await GetByIdAsync(id);
            if (bookies == null) return null;
            _context.Books.Remove(bookies);
            await _context.SaveChangesAsync();
            return bookies;

        }
        public async Task<List<Book>> GetAllAsync() => await _context.Books.OrderBy(b => b.Title).ToListAsync();

        public async Task<IEnumerable<Book>> GetAvailableAsync() => await _context.Books.Where(b => b.IsAvailable).ToListAsync();
        
        public async Task<Book?> GetByIdAsync(int id) => await _context.Books.FindAsync(id); 
        
        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
