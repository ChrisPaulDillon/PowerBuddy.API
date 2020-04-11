using System.Threading.Tasks;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Services;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatRepository : IRepositoryBase<LiftingStat>
    {
        /// <summary>
        /// Gets the lifting stats associated with a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<LiftingStat> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Updates lifting stats for a given user
        /// </summary>
        /// <param name="liftingStats"></param>
        void UpdateLiftingStats(LiftingStat liftingStats);
    }
}
