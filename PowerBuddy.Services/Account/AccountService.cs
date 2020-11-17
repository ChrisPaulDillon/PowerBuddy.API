using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Users;

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

        public IQueryable<UserDTO> GetAccountQueryable(string userId)
        {
            return _context.User.AsNoTracking()
                .Where(x => x.Id == userId)
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider);
        }

        public IQueryable<ProgramLogDTO> GetProgramLogsQueryable(string userId)
        {
            return _context.ProgramLog.AsNoTracking()
                .Where(x => x.UserId == userId)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider);
        }

        public IQueryable<ProgramLogDTO> GetProgramLogQueryable(string userId)
        {
            return _context.ProgramLog.AsNoTracking()
                .Where(x => x.UserId == userId)
                .ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider);
        }

        public IQueryable<LiftingStatDTO> GetLiftingStatsQueryable(string userId)
        {
            return _context.LiftingStat.AsNoTracking()
                .Where(x => x.UserId == userId)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider);
        }

        public bool IsUserModerator(string userId)
        {
            return _context.User.AsNoTracking().Any(x => x.Id == userId && x.MemberStatusId >= 2);
        }

        public async Task<bool> IsUserProfilePublic(string userId)
        {
            return await _context.User.AsNoTracking().AnyAsync(x => x.IsPublic == true);
        }
    }
}
