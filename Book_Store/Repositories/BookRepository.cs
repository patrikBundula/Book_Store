using AutoMapper;
using Book_Store.Dtos;
using Book_Store.Interface;

namespace Book_Store.Repositories
{
    public class BookRepository : Repository<Books>, IBookRepository
    {
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext contex, IMapper mapper) : base(contex, mapper)
        {
            _mapper = mapper;
        }

        public Author GetAuthorById(int authorId)
        {

            return BookStoreContext.Authors.FirstOrDefault(auth => auth.Id == authorId);
        }

        public Category GetCategoryById(int categoryId)
        {
            return BookStoreContext.Categories.FirstOrDefault(cat => cat.Id == categoryId);
        }

        public Books EditBook(BookDto book)
        {
            var bookFromDb = BookStoreContext.Books.Find(book.Id);
            var mappedResult = _mapper.Map<BookDto, Books>(book);

            bookFromDb = mappedResult;

            BookStoreContext.SaveChanges();


            return bookFromDb;
        }

        public void DeleteBookById(int bookId)
        {
            var book = BookStoreContext.Books.Find(bookId);
            book.IsDeleted = true;
            BookStoreContext.SaveChanges();
        }

        public BookStoreContext BookStoreContext
        {
            get { return _dbContext as BookStoreContext; }
        }

    }
}
