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


        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

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


            if (book == null) return NotFound(string.Format("Book with id = {0} not found", bookId));

            return Ok(book);
        }
        [HttpPost]
        public ActionResult AddNewBook([FromBody] BookDto book)
        {
            var mappedBook = _mapper.Map<BookDto, Books>(book);


            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                return NotFound(string.Format("Author with id = {0} not found", book.AuthorId));
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                return NotFound(string.Format("Book with id = {0} not found", book.CategoryId));

            }


            _unitOfWork.BookRepository.Add(mappedBook);

            return Ok();

        }
        [HttpPut]
        public ActionResult<BookDto> EditBook([FromBody] BookDto book)
        {

            if (_unitOfWork.BookRepository.GetAuthorById(book.AuthorId) is null)
            {
                return NotFound(string.Format("Author with id = {0} not found", book.AuthorId));
            }

            if (_unitOfWork.BookRepository.GetCategoryById(book.CategoryId) is null)
            {
                return NotFound(string.Format("Book with id = {0} not found", book.CategoryId));

            }


            var result = _unitOfWork.BookRepository.EditBook(book);

            return Ok(result);
        }

        [HttpDelete("{bookId}")]
        public ActionResult DeleteBook(int bookId)
        {

            if (_unitOfWork.BookRepository.Get(bookId) is null)
            {
                return NotFound(string.Format("Book with id = {0} not found", bookId));
            }

            _unitOfWork.BookRepository.DeleteBookById(bookId);

            return Ok();
        }


    }
}