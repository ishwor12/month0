using Library_Book_Management_API.Models;
using Library_Book_Management_API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library_Book_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            
            => Ok(await _bookService.GetAllAsync());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var books = await _bookService.GetByIdAsync(id);
            return books == null ? NotFound() : Ok(books);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Book books)
        {
            var available = await _bookService.CreateAsync(books);
            return CreatedAtAction(nameof(GetById),new { id=available.Id}, available);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Book book)
        {
            var updated = await _bookService.UpdateAsync(id, book);
            if (updated == null)
                return NotFound(new { message = $"Book {id} not found." });
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _bookService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { message = $"Book {id} not found." });
            return NoContent();
        }

    }
}
