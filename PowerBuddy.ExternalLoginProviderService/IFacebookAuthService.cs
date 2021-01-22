using System.Threading.Tasks;
using PowerBuddy.ExternalLoginProviderService.Models;

namespace PowerBuddy.ExternalLoginProviderService
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}
