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

            if (result is null)
            {
                return BadRequest("Something went wrong, can not be added a new book");
            }

            return Ok(result.Value);

        }
        [HttpPut]
        public ActionResult<Books> EditBook([FromBody] EditBookDto book)
        {
            var result = _dataRepository.EditBook(book);

            if (result is null)
            {
                return BadRequest("Something went wrong, can not be added a new book");
            }

            return Ok(result);
        }


    }
}