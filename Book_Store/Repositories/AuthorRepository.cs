using AutoMapper;
using Book_Store.Interface;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {

        public AuthorRepository(BookStoreContext contex, IMapper mapper) : base(contex, mapper)
        {

        }

        public Author GetAuthorWithBooks(int id)
        {
            return BookStoreContext.Authors.Include(a => a.Books).SingleOrDefault(a => a.Id == id);
        }

        public BookStoreContext BookStoreContext
        {
            get { return _dbContext as BookStoreContext; }
        }
    }
}
