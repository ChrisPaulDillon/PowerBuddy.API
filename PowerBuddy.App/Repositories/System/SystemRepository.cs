using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.System;

namespace PowerBuddy.App.Repositories.System
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

        public async Task<IEnumerable<GenderDto>> GetAllGenders()
        {
            return await _context.Gender
                .AsNoTracking()
                .ProjectTo<GenderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberStatusDto>> GetAllMemberStatus()
        {
            return await _context.MemberStatus
                .AsNoTracking()
                .ProjectTo<MemberStatusDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<LiftingLevelDto>> GetAllLiftingLevels()
        {
            return await _context.MemberStatus
                .AsNoTracking()
                .ProjectTo<LiftingLevelDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
