using Book_Store.Dtos;
namespace Book_Store.Interface
{
    public interface IBookAppService
    {
        List<Books> GetAllBooks();

        Books GetBookInfo(int bookId);

        int? AddNewBook(BookDto book);

        Books? EditBook(BookDto book);

        Author GetAuthorById(int authorId);

        Category GetCategoryById(int categoryId);
    }
}
