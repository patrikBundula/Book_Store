using Book_Store.Dtos;
namespace Book_Store.Interface
{
    public interface IBookRepository : IRepository<Books>
    {
        Author GetAuthorById(int authorId);

        Category GetCategoryById(int categoryId);

        Books EditBook(BookDto book);
        void DeleteBookById(int bookId);
    }
}
