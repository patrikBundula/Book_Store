using Database.Entity;

namespace Model.Interface
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }

        IUserRepository<string, User> UserRepository { get; }

    }
}
