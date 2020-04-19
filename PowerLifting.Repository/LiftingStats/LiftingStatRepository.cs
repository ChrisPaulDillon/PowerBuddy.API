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

        public async Task<LiftingStat> GetLiftingStatsByUserId(string userId)
        {
            return await PowerliftingContext.Set<LiftingStat>().Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        public void UpdateLiftingStats(LiftingStat liftingStats)
        {
            Update(liftingStats);
        }
    }
}
