using Library_Book_Management_API.Models;

namespace Library_Book_Management_API.Service.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<Book?> UpdateAsync(int id, Book book);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Book>> GetAvailableAsync();
        Task<Book?> BorrowBookAsync(int id);   
        Task<Book?> ReturnBookAsync(int id);


    }
}
