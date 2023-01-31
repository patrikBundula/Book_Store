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

        public int? AddNewBook(BookDto book)
        {
            var mappedResult = _mapper.Map<BookDto, Books>(book);
            var bookEntity = _bookStoreContext.Books.Add(mappedResult);

            var success = _bookStoreContext.SaveChanges() > 0;

            return success ? bookEntity.Entity.Id : null;


        }

        public Books EditBook(EditBookDto book)
        {
            var mappedResult = _mapper.Map<EditBookDto, Books>(book);
            _bookStoreContext.Attach(mappedResult);


            _bookStoreContext.Entry(mappedResult).State = EntityState.Modified;
            _bookStoreContext.SaveChanges();

            return mappedResult;
        }
    }
}
