using PowerLifting.Data.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.Entities;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.Service.Account
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
    }
}
