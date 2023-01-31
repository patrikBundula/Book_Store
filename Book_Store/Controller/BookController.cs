using Book_Store.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controller
{
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _dataRepository;

        public BookController(IBookAppService dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/books")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _dataRepository.GetAllBooks();

            if (books == null) return BadRequest("Db is empty");

            return Ok(books);
        }
        [Route("api/books/{bookId}")]
        [HttpGet]
        public async Task<ActionResult> GetBookInfo(int bookId)
        {
            var book = await _dataRepository.GetBookInfo(bookId);

            if (book == null) return BadRequest("There was an issue finding the book");

            return Ok(book);
        }
    }
}