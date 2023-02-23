using Database.Entity;
using Model.Interface;

namespace Model.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithBooks(int id);
    }
}
