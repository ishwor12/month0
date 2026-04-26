using Library_Book_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Book_Management_API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
