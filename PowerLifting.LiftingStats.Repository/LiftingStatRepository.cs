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
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId)
                                                               .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                                                               .AsNoTracking()
                                                               .ToListAsync();
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return await _context.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange && u.Weight != null)
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

        public async Task<bool> DoesLiftingStatExist(int liftingStatId)
        {
            return await _context.LiftingStat.Where(x => x.LiftingStatId == liftingStatId).AsNoTracking().AnyAsync();
        }

        public async Task<bool> DoesLiftingStatExistByExerciseAndRep(string userId, int exerciseId, int repRange)
        {
            return await _context.LiftingStat.Where(x => x.UserId == userId && x.ExerciseId == exerciseId && x.RepRange == repRange).AnyAsync();
        }

        public async Task<bool> UpdateLiftingStatCollection(IEnumerable<LiftingStatDTO> liftingStatCollectionDTO)
        {
            var liftingStatCollection = _mapper.Map<LiftingStat>(liftingStatCollectionDTO);
            _context.LiftingStat.Attach(liftingStatCollection);
            return await SaveChangesAsync();
        }
    }
}
