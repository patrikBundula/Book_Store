using Book_Store.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controller
{
    public class BookController : ControllerBase
    {
        private readonly IBookAppService _dataRepository;

        public BookController(IBookAppService dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [Route("api/books")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Books> books = await _dataRepository.GetAllBooks();
            return Ok(books);
        }
    }
}
