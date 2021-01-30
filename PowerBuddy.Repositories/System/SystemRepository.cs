using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.System;
using PowerBuddy.Services.System;

namespace PowerBuddy.Repositories.System
{
    public class SystemRepository : ISystemRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public SystemRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenderDTO>> GetAllGenders()
        {
            return await _context.Gender
                .AsNoTracking()
                .ProjectTo<GenderDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberStatusDTO>> GetAllMemberStatus()
        {
            return await _context.MemberStatus
                .AsNoTracking()
                .ProjectTo<MemberStatusDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<LiftingLevelDTO>> GetAllLiftingLevels()
        {
            return await _context.MemberStatus
                .AsNoTracking()
                .ProjectTo<LiftingLevelDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
