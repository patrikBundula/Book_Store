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

        public async Task<List<Books>> GetAllBooks()
        {
            return await _bookStoreContext.Books.ToListAsync();

        }


        public async Task<Books> GetBookInfo(int bookId)
        {
            return await _bookStoreContext.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> AddNewBook([FromBody] BookDto book)
        {
            var mappedResult = _mapper.Map<BookDto, Books>(book);
            _bookStoreContext.Books.Add(mappedResult);

            var success = await _bookStoreContext.SaveChangesAsync() > 0;

            if (!success)
            {
                return IdentityResult.Failed();
            }

            return IdentityResult.Success;


        }
    }
}
