﻿using AutoMapper;
using Book_Store.Interface;
using Book_Store.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _dbContext;
        private readonly IMapper _mapper;

        public UnitOfWork(BookStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IAuthorRepository AuthorRepository => new AuthorRepository(_dbContext, _mapper);
        public IBookRepository BookRepository => new BookRepository(_dbContext, _mapper);

    }
}