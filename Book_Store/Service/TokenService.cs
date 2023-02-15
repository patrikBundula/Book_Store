namespace Book_Store.Service
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);

    }
    public class TokenService
    {
    }
}
