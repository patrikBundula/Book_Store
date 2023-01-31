using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

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
            return await _bookStoreContext.Books.ToListAsync();

        }


        public async Task<Books> GetBookInfo(int bookId)
        {
            return await _bookStoreContext.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();
        }
    }
}
