using System.Threading.Tasks;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entity.Entities;
using PowerLifting.Entity.Entities.Data;

namespace Powerlifting.Repository.Repositories
{
    public class LiftingStatsRepository : RepositoryBase<LiftingStats>, ILiftingStatsRepository
    {
        public LiftingStatsRepository(PowerliftingContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void UpdateLiftingStats(LiftingStats stats)
        {
            Update(stats);
        }

        public async Task<LiftingStats> GetLiftingStatsByIdAsync(int id)
        {
            return await GetByCondition(x => x.LiftingStatsId == id);
        }
    }
}
