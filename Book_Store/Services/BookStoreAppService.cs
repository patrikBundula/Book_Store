using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Book_Store.Dtos;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace Book_Store.Services
{
    public class BookStoreAppService : IBookAppService
    {
        private readonly BookStoreContext _bookStoreContext;
        private readonly IMapper _mapper;


        public BookStoreAppService(BookStoreContext context, IMapper mapper)
        {
            _bookStoreContext = context;
            _mapper = mapper;
        }

        public List<Books> GetAllBooks()
        {
            return _bookStoreContext.Books.ToList();

        }


        public Books GetBookInfo(int bookId)
        {
            return _bookStoreContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public Author GetAuthorById(int authorId)
        {
            return _bookStoreContext.Authors.FirstOrDefault(auth => auth.Id == authorId);
        }

        public Category GetCategoryById(int categoryId)
        {
            return _bookStoreContext.Categories.FirstOrDefault(cat => cat.Id == categoryId);
        }
        public int? AddNewBook(BookDto book)
        {
            var mappedResult = _mapper.Map<BookDto, Books>(book);
            var bookEntity = _bookStoreContext.Books.Add(mappedResult);

            var success = _bookStoreContext.SaveChanges() > 0;

            return success ? bookEntity.Entity.Id : null;


        }

        public Books EditBook(BookDto book)
        {
            var mappedResult = _mapper.Map<BookDto, Books>(book);
            _bookStoreContext.Attach(mappedResult);
            _bookStoreContext.Entry(mappedResult).State = EntityState.Modified;
            _bookStoreContext.SaveChanges();

            return mappedResult;
        }

        public void DeleteBookById(int bookId)
        {
            _bookStoreContext.Remove(_bookStoreContext.Books.FirstOrDefault(b => b.Id == bookId));
            _bookStoreContext.SaveChanges();
        }


    }
}
