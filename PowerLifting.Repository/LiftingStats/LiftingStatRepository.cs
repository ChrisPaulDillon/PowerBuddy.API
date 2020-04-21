using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStats;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;

namespace PowerLifting.Repository.LiftingStats
{
    public class LiftingStatRepository : RepositoryBase<LiftingStat>, ILiftingStatRepository
    {
        public LiftingStatRepository(PowerliftingContext context) : base(context)
        {
        }

        public void CreateLiftingStat(LiftingStat liftingStat)
        {
            Create(liftingStat);
        }

        public async Task<LiftingStat> GetLiftingStatsByUserId(string userId)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<LiftingStat> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId && u.RepRange == repRange).FirstOrDefaultAsync();
        }

        public void UpdateLiftingStats(LiftingStat liftingStats)
        {
            Update(liftingStats);
        }
    }
}
