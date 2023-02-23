using AutoMapper;
using Database;
using Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Interface;
using System.Linq.Expressions;

namespace Logic.Repositories
{
    public class UserRepository : IUserRepository<string, User>
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly BookStoreContext _dbContext;
        private readonly DbSet<User> _dbSet;
        private readonly IMapper _mapper;



        public UserRepository(IMapper mapper, ILogger<UserRepository> logger, BookStoreContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
            _dbSet = dbContext.Set<User>();


        }

        public User Get(Expression<Func<User, bool>> predicate) => _dbSet.FirstOrDefault(predicate);


    }
}
