using System.Threading.Tasks;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.Data.DTOs.Users;

namespace PowerBuddy.App.Services.Authentication
{
    public interface ITokenService
    {
        /// <summary>
        /// Called upon successful authentication (either via login, register or refresh)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<AuthenticationResultDTO> CreateRefreshTokenAuthenticationResult(string userId, UserDTO user);

        public Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
