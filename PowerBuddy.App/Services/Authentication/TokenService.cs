using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Authentication.Models;
using PowerBuddy.AuthenticationService;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Factories;

namespace PowerBuddy.App.Services.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly PowerLiftingContext _context;
        private readonly IAuthService _authService;
        private readonly IEntityFactory _entityFactory;

        public TokenService(PowerLiftingContext context, IAuthService authService, IEntityFactory entityFactory)
        {
            _context = context;
            _authService = authService;
            _entityFactory = entityFactory;
        }

        public async Task<AuthenticationResultDto> CreateRefreshTokenAuthenticationResult(string userId, UserDto user)
        {
            if (user == null)
            {
                user = await _context.User
                    .AsNoTracking()
                    .Where(x => x.Id == userId)
                    .Select(x => new UserDto()
                    {
                        UserId = x.Id,
                        UserName = x.UserName,
                        UsingMetric = x.UserSetting.UsingMetric,
                        FirstVisit = x.FirstVisit,
                        MemberStatusId = x.MemberStatusId?? 0
                    })
                    .FirstOrDefaultAsync();
            }
            
            var accessToken = _authService.GenerateJwtToken(userId, user.UserName, user.UsingMetric, user.FirstVisit, user.MemberStatusId);
            var refreshToken = _entityFactory.CreateRefreshToken(accessToken, userId);

            _context.RefreshToken.Add(refreshToken);
            await _context.SaveChangesAsync();

            var authenticatedUser = new AuthenticationResultDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
            };

            return authenticatedUser;
        }

        public async Task<bool> RevokeRefreshTokenAsync(string refreshToken)
        {
            var token = await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == refreshToken);

            if (token == null)
            {
                return false;
            }

            token.IsUsed = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
