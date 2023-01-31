using Book_Store.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Interface
{
    public interface IBookAppService
    {
        Task<List<Books>> GetAllBooks();

        Task<Books> GetBookInfo(int bookId);

        Task<IdentityResult> AddNewBook(BookDto book);

    }
}
