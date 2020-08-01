using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.LiftingStats.Repository
{
    public class LiftingStatRepository : ILiftingStatRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //do we still need this?
        public async Task<LiftingStatDTO> GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange)
        {
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId &&
                                                                      u.RepRange == repRange &&
                                                                      u.ExerciseId == exerciseId)
                                                                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                                                                .AsNoTracking()
                                                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId)
        {
           
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
           
        }

        public async Task<LiftingStat> GetLiftingStatById(int liftingStatId)
        {
            return await _context.Set<LiftingStat>().Where(x => x.LiftingStatId == liftingStatId)
                                                               .FirstOrDefaultAsync();
        }

        public async Task<LiftingStat> CreateLiftingStat(LiftingStatDTO liftingStat)
        {
            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStat);
            _context.Add(liftingStatEntity);
            await _context.SaveChangesAsync();
            return liftingStatEntity;
        }

        public async Task<bool> UpdateLiftingStat(LiftingStatDTO liftingStat)
        {
           
        }

        public async Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStat)
        {
            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStat);
            _context.Remove(liftingStatEntity);
            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DoesLiftingStatExist(int liftingStatId)
        {
            return 
        }

        public async Task<bool> DoesLiftingStatExistByExerciseAndRep(string userId, int exerciseId, int repRange)
        {
            return await
        }
    }
}
