using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.System;
using PowerLifting.Persistence;

namespace PowerLifting.Systems.Service
{
    public class TemplateDifficultyService : ITemplateDifficultyService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateDifficultyService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TemplateDifficultyDTO>> GetAllTemplateDifficulties()
        {
            return await _context.Set<TemplateDifficulty>()
                .ProjectTo<TemplateDifficultyDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}