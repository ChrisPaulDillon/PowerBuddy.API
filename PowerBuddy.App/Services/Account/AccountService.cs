using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.App.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly PowerLiftingContext _context;

        public AccountService(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesUserExist(string userId)
        {
            return await _context.User.AsNoTracking().AnyAsync(x => x.Id == userId);
        }

        public bool IsUserModerator(string userId)
        {
            return _context.User.AsNoTracking().Any(x => x.Id == userId && x.MemberStatusId >= 2);
        }

        public async Task<bool> IsUserProfilePublic(string userId)
        {
            return await _context.User.AsNoTracking().AnyAsync(x => x.IsPublic);
        }

        public async Task<int> GetTotalUserCount()
        {
            return await _context.User.AsNoTracking().CountAsync();
        }

        public async Task<bool> IsUserUsingMetric(string userId)
        {
            return await _context.UserSetting
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => x.UsingMetric)
                .FirstOrDefaultAsync();
        }
    }
}
