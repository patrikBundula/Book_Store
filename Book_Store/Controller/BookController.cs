using Book_Store.Dtos;
using Book_Store.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Book_Store.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public ActionResult<Books> GetAll()
        {
            var books = _unitOfWork.BookRepository.GetAll();

            if (books == null) return BadRequest("Db is empty");

            return Ok(books);
        }
        [HttpGet("{bookId}")]
        public ActionResult<Books> GetBookInfo(int bookId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);

            if (book == null) return BadRequest("There was an issue finding the book");

            return Ok(book);
        }
        [HttpPost]
        public ActionResult AddNewBook([FromBody] BookDto book)
        {
            var mappedBook = _mapper.Map<BookDto, Books>(book);


            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                return BadRequest("Sorry Author is not found");
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                return BadRequest("Sorry Category is not found");

            }


            _unitOfWork.BookRepository.Add(mappedBook);

            return Ok();

        }
        [HttpPut]
        public ActionResult<Books> EditBook([FromBody] BookDto book)
        {

            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                return BadRequest("Sorry Author is not found");
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                return BadRequest("Sorry Category is not found");

            }


            var result = _unitOfWork.BookRepository.EditBook(book);

            return Ok(result);
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook(int bookId)
        {

            if (_unitOfWork.BookRepository.Get(bookId) is null)
            {
                return BadRequest("There was an issue finding the book");
            }

            _unitOfWork.BookRepository.DeleteBookById(bookId);

            return Ok();
        }


    }
}