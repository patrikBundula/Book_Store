using Book_Store.Dtos;
using Book_Store.Interface;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Book_Store.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _dataRepository;

        public BookController(IBookAppService dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public ActionResult<Books> Get()
        {
            var books = _dataRepository.GetAllBooks();

            if (books == null) return BadRequest("Db is empty");

            return Ok(books);
        }
        [HttpGet("{bookId}")]
        public ActionResult<Books> GetBookInfo(int bookId)
        {
            var book = _dataRepository.GetBookInfo(bookId);

            if (book == null) return BadRequest("There was an issue finding the book");

            return Ok(book);
        }
        [HttpPost]
        public ActionResult<int> AddNewBook([FromBody] BookDto book)
        {
            var result = _dataRepository.AddNewBook(book);

            if (_dataRepository.GetAuthorById(book.AuthorId) is null)
            {
                return BadRequest("Sorry Author is not found");
            }

            if (_dataRepository.GetCategoryById(book.CategoryId) is null)
            {
                return BadRequest("Sorry Category is not found");

            }



            return Ok(result.Value);

        }
        [HttpPut]
        public ActionResult<Books> EditBook([FromBody] BookDto book)
        {

            if (_dataRepository.GetAuthorById(book.AuthorId) is null)
            {
                return BadRequest("Sorry Author is not found");
            }

            if (_dataRepository.GetCategoryById(book.CategoryId) is null)
            {
                return BadRequest("Sorry Category is not found");

            }


            var result = _dataRepository.EditBook(book);

            return Ok(result);
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook(int bookId)
        {

            if (_dataRepository.GetBookInfo(bookId) is null)
            {
                return BadRequest("There was an issue finding the book");
            }

            _dataRepository.DeleteBookById(bookId);

            return Ok();
        }


    }
}