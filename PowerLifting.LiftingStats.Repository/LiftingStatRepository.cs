using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;
using System.Collections.Generic;
using PowerLifting.LiftingStats.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.LiftingStats.Repository
{
    public class LiftingStatRepository : ILiftingStatRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public LiftingStatRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

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
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId)
                                                               .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                                                               .AsNoTracking()
                                                               .ToListAsync();
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange)
                                                               .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                                                               .AsNoTracking()
                                                               .ToListAsync();
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

        public void CreateLiftingStatNoSave(LiftingStat liftingStat)
        {
            _context.Add(liftingStat);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> UpdateLiftingStat(LiftingStatDTO liftingStat)
        {
            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStat);
            _context.Update(liftingStatEntity);
            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStat)
        {
            var liftingStatEntity = _mapper.Map<LiftingStat>(liftingStat);
            _context.Remove(liftingStatEntity);
            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
