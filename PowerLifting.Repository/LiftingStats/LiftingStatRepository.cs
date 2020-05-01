using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStats;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;
using System.Collections.Generic;

namespace PowerLifting.Repository.LiftingStats
{
    public class LiftingStatRepository : RepositoryBase<LiftingStat>, ILiftingStatRepository
    {
        public LiftingStatRepository(PowerliftingContext context) : base(context)
        {
        }

        public async Task<LiftingStat> GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId &&
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

        public void CreateLiftingStat(LiftingStat liftingStat)
        {
            Create(liftingStat);
        }

        public void UpdateLiftingStat(LiftingStat liftingStat)
        {
            Update(liftingStat);
        }

        public void DeleteLiftingStat(LiftingStat liftingStat)
        {
            Delete(liftingStat);
        }
    }
}
