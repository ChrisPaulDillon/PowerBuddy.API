using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;

namespace PowerBuddy.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public AccountService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool IsUserModerator(string userId)
        {
            return _context.User.AsNoTracking().Any(x => x.Id == userId && x.MemberStatusId >= 2);
        }

        public async Task<bool> IsUserProfilePublic(string userId)
        {
            return await _context.User.AsNoTracking().AnyAsync(x => x.IsPublic == true);
        }

        public async Task<int> GetTotalUserCount()
        {
            return await _context.User.AsNoTracking().CountAsync();
        }
    }
}
