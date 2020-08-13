using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Exercises;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Exceptions.LiftingStats;
using PowerLifting.Persistence;

namespace PowerLifting.LiftingStats.Service
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateLiftingStatsByAthleteType(string userId, IEnumerable<TopLevelExerciseDTO> exercises)
        {
        
        }

        public async Task<LiftingStatDTO> CreateLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            
        }

        public async Task<bool> UpdateLiftingStat(LiftingStatDTO stats)
        {
        
        }

        public async Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var liftingStat = await _context.LiftingStat.Where(x => x.LiftingStatId == liftingStatDTO.LiftingStatId).AsNoTracking().AnyAsync();
            if (!liftingStat) throw new LiftingStatNotFoundException();

            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStatDTO);
            _context.Remove(liftingStatEntity);

            var modifiedRows = await _context.SaveChangesAsync();

            return modifiedRows > 0;
        }

        public async Task<bool> UpdateLiftingStatCollection(IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
           
        }
    }
}