using Database.Entity;
using Model.Dtos;
using Model.Interface;

namespace Model.Interface
{
    public interface IBookRepository : IRepository<Books>
    {
        Author GetAuthorById(int authorId);

        Category GetCategoryById(int categoryId);

        Books EditBook(BookDto book);
        void DeleteBookById(int bookId);
    }
}
