using AutoMapper;
using Database.Entity;
using Microsoft.AspNetCore.Mvc;
using Model.Interface;

namespace Book_Store.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult<Author> GetAll()
        {

            var authors = _unitOfWork.AuthorRepository.GetAll();

            if (authors == null) return NotFound("No Authors in the Db");

            return Ok(authors);
        }
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthorWithBooks(int id)
        {
            var author = _unitOfWork.AuthorRepository.GetAuthorWithBooks(id);

            if (author == null)
            {
                return NotFound(string.Format("Author with id = {0} not found", id)
);
            }

            return Ok(author);
        }

    }
}
