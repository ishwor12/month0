using Library_Book_Management_API.Models;

namespace Library_Book_Management_API.Repository.Interface
{
    public interface IBookRepository
    {
        Task <List<Book>> GetAllAsync();
        Task <Book> AddAsync( Book book);
        Task <Book?> DeleteAsync( int id);
        Task<Book?> GetByIdAsync(int id);
        Task <Book>UpdateAsync(Book book);
        Task<IEnumerable<Book>> GetAvailableAsync();
    }
}
