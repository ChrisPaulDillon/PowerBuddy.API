using System.Threading.Tasks;
using PowerBuddy.Services.Authentication.Models;

namespace PowerBuddy.Services.Authentication
{
    public interface ITokenService
    {
        /// <summary>
        /// Called upon successful authentication (either via login, register or refresh)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<AuthenticatedUserDTO> CreateRefreshTokenAuthenticationResult(string userId);

        public Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
