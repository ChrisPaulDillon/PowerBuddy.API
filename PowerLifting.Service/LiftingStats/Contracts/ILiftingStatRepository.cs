using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.Model;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatRepository : IRepositoryBase<LiftingStat>
    {
        /// <summary>
        /// Gets a specific lifting stat rep range for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="repRange"></param>
        /// <returns></returns>
        Task<LiftingStat> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange);
        /// <summary>
        /// Gets the lifting stats associated with a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<LiftingStat> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Creates a new lifting stat for a given rep range for a specific user
        /// </summary>
        /// <param name="liftingStat"></param>
        void CreateLiftingStat(LiftingStat liftingStat);

        /// <summary>
        /// Updates lifting stats for a given user
        /// </summary>
        /// <param name="liftingStats"></param>
        void UpdateLiftingStats(LiftingStat liftingStats);
    }
}