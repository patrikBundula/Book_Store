using Book_Store.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace Book_Store.Service
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
        Task<TokenRequestDto> ValidateRefreshToken(TokenRequestDto request);
        Task<string> CreateRefreshToken(User user);

    }
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly SymmetricSecurityKey _key;



        public TokenService(IConfiguration config, UserManager<User> userManager)
        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }


        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)

            };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<string> CreateRefreshToken(User user)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, TokenOptions.DefaultProvider, "RefreshToken");
            var refreshtoken = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "RefreshToken");
            await _userManager.SetAuthenticationTokenAsync(user, TokenOptions.DefaultProvider, "RefreshToken", refreshtoken);
            return refreshtoken;
        }

        public async Task<TokenRequestDto> ValidateRefreshToken(TokenRequestDto request)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenContent = tokenhandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.NameId)?.Value;
            var user = await _userManager.FindByNameAsync(username);
            var isValid = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "RefreshToken", request.RefreshToken);
            if (isValid)
            {
                return new TokenRequestDto()
                {
                    Token = await CreateToken(user),
                    RefreshToken = await CreateRefreshToken(user)
                };
            }

            await _userManager.UpdateSecurityStampAsync(user);

            return null;
        }

    }


}
