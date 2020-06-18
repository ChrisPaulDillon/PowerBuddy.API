using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;
using System.Collections.Generic;
using Powerlifting.Common;
using PowerLifting.LiftingStats.Contracts;

namespace PowerLifting.LiftingStats.Repository
{
    public class LiftingStatRepository : RepositoryBase<LiftingStat>, ILiftingStatRepository
    {
        public LiftingStatRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<LiftingStat> GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange)
        {
            return await PowerliftingContext.Set<LiftingStat>().AsNoTracking().Where(u => u.UserId == userId &&
                                                                      u.RepRange == repRange &&
                                                                      u.ExerciseId == exerciseId).
                                                                      FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserId(string userId)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId).Include(x => x.Exercise).ToListAsync();
        }

        public async Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange)
                                                               .ToListAsync();
        }

        public async Task<LiftingStat> GetLiftingStatById(int liftingStatId)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(x => x.LiftingStatId == liftingStatId).FirstOrDefaultAsync();
        }

        public async Task CreateLiftingStat(LiftingStat liftingStat)
        {
            await Create(liftingStat);
        }

        public async Task<bool> UpdateLiftingStat(LiftingStat liftingStat)
        {
            return await Update(liftingStat);
        }

        public async Task<bool> DeleteLiftingStat(LiftingStat liftingStat)
        {
            return await Delete(liftingStat);
        }
    }
}
