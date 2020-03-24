using System.Threading.Tasks;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;

namespace Powerlifting.Services.Service
{
    public class LiftingStatService : ServiceBase<LiftingStat>, ILiftingStatService
    {
        public LiftingStatService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {
        }

        public void UpdateLiftingStats(LiftingStat stats)
        {
            Update(stats);
        }

        public async Task<LiftingStat> GetLiftingStatsByIdAsync(int id)
        {
            return await GetByCondition(x => x.LiftingStatId == id);
        }
    }
}
