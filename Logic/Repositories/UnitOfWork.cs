using AutoMapper;
using Database;
using Database.Entity;
using Microsoft.Extensions.Logging;
using Model.Interface;

namespace Logic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerFactory _loggerFactory;




        public UnitOfWork(BookStoreContext dbContext, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _loggerFactory = loggerFactory;
        }
        public IUserRepository<string, User> UserRepository => new UserRepository(_mapper, _loggerFactory.CreateLogger<UserRepository>(), _dbContext);
        public IAuthorRepository AuthorRepository => new AuthorRepository(_dbContext, _mapper);
        public IBookRepository BookRepository => new BookRepository(_dbContext, _mapper);

    }
}
