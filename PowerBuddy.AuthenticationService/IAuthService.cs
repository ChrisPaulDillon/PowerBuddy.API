using System.Security.Claims;
using System.Threading.Tasks;

namespace PowerBuddy.AuthenticationService
{
    public interface IAuthService
    {
        public Task<string> RefreshTokenAsync(string token, string refreshToken);
        public ClaimsPrincipal GetPrincipalFromToken(string token);
        public string GenerateJwtToken(string userId, string userName, bool usingMetric, bool firstVisit, int memberStatusId);
    }
}
