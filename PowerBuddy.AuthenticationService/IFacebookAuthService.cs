using System.Threading.Tasks;
using PowerBuddy.AuthenticationService.Models;

namespace PowerBuddy.AuthenticationService
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
