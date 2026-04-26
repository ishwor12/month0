using Library_Book_Management_API.Models;
using Library_Book_Management_API.Repository;
using Library_Book_Management_API.Repository.Interface;
using Library_Book_Management_API.Service.Interface;

namespace Library_Book_Management_API.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book?> BorrowBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> CreateAsync(Book book)
        {
            book.AddedDate = DateTime.UtcNow;
            book.IsAvailable = true;
            return await _bookRepository.AddAsync(book);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _bookRepository.DeleteAsync(id);
            return deleted != null;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()=> await _bookRepository.GetAllAsync();

        public async Task<IEnumerable<Book>> GetAvailableAsync()
        => await _bookRepository.GetAvailableAsync();

        public async Task<Book?> GetByIdAsync(int id)=> await _bookRepository.GetByIdAsync(id);

        public Task<Book?> ReturnBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> UpdateAsync(int id, Book book)
        {
            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.Genre = book.Genre;
            return await _bookRepository.UpdateAsync(existing);
        }
    }
}
