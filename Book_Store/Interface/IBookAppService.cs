namespace Book_Store.Interface
{
    public interface IBookAppService
    {
        Task<List<Books>> GetAllBooks();

        Task<Books> GetBookInfo(int bookId);
    }
}
