using PowerLifting.Accounts.Contracts.Repositories;
using PowerLifting.Persistence;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.Accounts.Repository
{
    public class UserSettingRepository : IUserSettingRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public UserSettingRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserSettingDTO> GetUserSettingsById(string userId)
        {
            return await _context.UserSetting
                .Where(x => x.UserId == userId)
                .ProjectTo<UserSettingDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        }
    }
}
