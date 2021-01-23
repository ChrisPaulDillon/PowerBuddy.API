using System.Threading.Tasks;

namespace PowerBuddy.AuthenticationService
{
    public interface IAuthService
    {
        public Task<string> RefreshTokenAsync(string token, string refreshToken);
        public string GenerateJwtToken(string userId);
    }
}
