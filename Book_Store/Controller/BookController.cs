using Book_Store.Dtos;
using Book_Store.Interface;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Net;

namespace Book_Store.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;


        public BookController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BookController> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<BookDto> GetAll()
        {
            var books = _unitOfWork.BookRepository.GetAll();

            if (books == null) return NotFound("Db is empty");

            return Ok(books);
        }
        [HttpGet("{bookId}")]
        public ActionResult<BookDto> GetBookInfo(int bookId)
        {
            var book = _unitOfWork.BookRepository.Get(bookId);
            var errorMessage = $"Book with id {bookId} was not found";

            if (book == null)
            {
                _logger.LogInformation(errorMessage);

                return NotFound(errorMessage);
            }

            return Ok(book);
        }
        [HttpPost]
        public ActionResult<uint> AddNewBook([FromBody] BookDto book)
        {
            var mappedBook = _mapper.Map<BookDto, Books>(book);


            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                var errorMessage = $"Author with this id ={book.AuthorId} was not found";

                _logger.LogInformation(errorMessage);

                return NotFound(errorMessage);
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                var errorMessage = $"Category with id= {book.CategoryId} was not found";

                _logger.LogInformation(errorMessage);

                return NotFound(errorMessage);

            }
            try
            {
                _unitOfWork.BookRepository.Add(mappedBook);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }


        }
        [HttpPut]
        public ActionResult<BookDto> EditBook([FromBody] BookDto book)
        {

            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                var errorMessage = $"Author with this id ={book.AuthorId} was not found";
                
                _logger.LogInformation(errorMessage);

                return NotFound(errorMessage);
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                var errorMessage = $"Category with id= {book.CategoryId} was not found";

                _logger.LogInformation(errorMessage);

                return NotFound(errorMessage);

            }

            try
            {
                return Ok(_unitOfWork.BookRepository.EditBook(book));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook(int bookId)
        {

            if (_unitOfWork.BookRepository.Get(bookId) is null)
            {
                return NotFound($"Book with id {bookId} was not found");
            }

            _unitOfWork.BookRepository.DeleteBookById(bookId);

            return Ok();
        }


    }
}