using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;
using System.Collections.Generic;
using Powerlifting.Common;
using PowerLifting.Contracts.Contracts;

namespace PowerLifting.Repository.LiftingStats
{
    public class LiftingStatRepository : RepositoryBase<LiftingStat>, ILiftingStatRepository
    {
        public LiftingStatRepository(PowerliftingContext context) : base(context)
        {
        }

        public LiftingStat GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange)
        {
            return PowerliftingContext.Set<LiftingStat>().AsNoTracking().Where(u => u.UserId == userId &&
                                                                      u.RepRange == repRange &&
                                                                      u.ExerciseId == exerciseId).
                                                                      FirstOrDefault();
        }

        public async Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserId(string userId)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId).Include(x => x.Exercise).ToListAsync();
        }

        public IEnumerable<LiftingStat> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange)
                                                               .ToList();
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
