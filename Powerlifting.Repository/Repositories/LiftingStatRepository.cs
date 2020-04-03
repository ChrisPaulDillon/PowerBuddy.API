using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Repository;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.LiftingStats;

namespace PowerLifting.Repository.Repositories
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
