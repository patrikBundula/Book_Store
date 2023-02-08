using AutoMapper;
using Book_Store.Dtos;
using Book_Store.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookStoreContext _db;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger, IMapper mapper, IUnitOfWork unitOfWork, BookStoreContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _db = db;
        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
        {
            var selectedRole = DefaultRoles.ValidRoles.FirstOrDefault(role => role.Equals(registrationDto.Role));
            Console.WriteLine(selectedRole);
            Console.WriteLine(registrationDto.Role);
            if (string.IsNullOrEmpty(selectedRole))
            {
                return BadRequest("Not existing role!");
            }

            if (_db.Users.Any(user => user.UserName.Equals(registrationDto.Username)))
            {
                return BadRequest("Username is already exist in the db!");
            }

            if (_db.Users.Any(user => user.Email.Equals(registrationDto.Email)))
            {
                return BadRequest("Email is already exist in the db!");
            }

            var user = new User()
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                UserName = registrationDto.Username,
                Email = registrationDto.Email,
                EmailConfirmed = true,

            };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded) return BadRequest("Registration failed");

            await _userManager.GenerateEmailConfirmationTokenAsync(user);
            _logger.LogInformation(user.Email);
            var roleResult = await _userManager.AddToRoleAsync(user, selectedRole);
            return roleResult.Succeeded ? Ok() : BadRequest("UserRole can not add");
        }

    }
}
