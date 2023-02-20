using AutoMapper;
using Book_Store.Dtos;
using Book_Store.Interface;
using Book_Store.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BookStoreContext _db;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger, IMapper mapper, IUnitOfWork unitOfWork, BookStoreContext db, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _db = db;
            _tokenService = tokenService;
        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
        {
            var selectedRole = DefaultRoles.ValidRoles.FirstOrDefault(role => role.Equals(registrationDto.Role));

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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            //itt a NormalizedUserName alapból nagy betűs verzióban jelenik meg az adatbázisban ezért vizsgáljuk a ToUpper methódussal a párját.
            var user = _unitOfWork.UserRepository.Get(user => user.NormalizedUserName == loginDto.Username.ToUpper());

            if (user == null) return Unauthorized("Something went wrong upon login");

            var validPassword = await _signInManager.UserManager.CheckPasswordAsync(user, loginDto.Password);

            if (!validPassword) return Unauthorized("Something went wrong upon login");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Something went wrong upon login");


            var dto = _mapper.Map<UserDto>(user);
            dto.Token = await _tokenService.CreateToken(user);
            dto.RefreshToken = await _tokenService.CreateRefreshToken(user);
            return dto;
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenRequestDto>> RefreshToken([FromBody] TokenRequestDto tokenRequestDto)
        {
            var token = await _tokenService.ValidateRefreshToken(tokenRequestDto);
            if (token == null)
            {
                return Unauthorized(new { message = "Invalid token" });
            }

            return Ok(token);
        }
    }
}
