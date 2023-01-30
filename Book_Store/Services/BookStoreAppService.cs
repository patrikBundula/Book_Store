using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Services
{
    public class BookStoreAppService : IBookAppService
    {
        readonly BookStoreContext _bookStoreContext;


        public BookStoreAppService(BookStoreContext context)
        {
            _bookStoreContext = context;
        }

        public async Task<List<Books>> GetAllBooks()
        {
            var books = await _bookStoreContext.Books.ToListAsync();
            return books;
        }
    }
}
