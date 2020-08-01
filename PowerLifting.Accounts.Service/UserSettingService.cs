using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Persistence;

namespace PowerLifting.Accounts.Service
{
    public class UserSettingService : IUserSettingService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UserSettingService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserSettingDTO> GetUserSettingsByUserId(string userId)
        {
            return await _context.UserSetting
                .Where(x => x.UserId == userId)
                .ProjectTo<UserSettingDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
