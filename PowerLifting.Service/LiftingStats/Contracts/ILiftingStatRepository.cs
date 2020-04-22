using System.Collections.Generic;
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
        Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange);

        /// <summary>
        /// Gets the lifting stats associated with a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Used to get a specific lifting stat for deletion or update
        /// </summary>
        /// <param name="liftingStatId"></param>
        /// <returns></returns>
        Task<LiftingStat> GetLiftingStatById(int liftingStatId);

        /// <summary>
        /// Used to determine if the user already has a lifting stat for this exercise and rep range
        /// </summary>
        /// <returns></returns>
        Task<LiftingStat> GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange);

        /// <summary>
        /// Creates a new lifting stat for a given rep range for a specific user
        /// </summary>
        /// <param name="liftingStat"></param>
        void CreateLiftingStat(LiftingStat liftingStat);

        /// <summary>
        /// Updates lifting stats for a given user
        /// </summary>
        /// <param name="liftingStats"></param>
        void UpdateLiftingStat(LiftingStat liftingStat);

        /// <summary>
        /// Deletes a given lifting stat
        /// </summary>
        /// <param name="liftingStat"></param>
        void DeleteLiftingStat(LiftingStat liftingStat);
    }
}