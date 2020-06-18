using System.Collections.Generic;
using System.Threading.Tasks;
using Powerlifting.Common;
using PowerLifting.Service.LiftingStats.Model;

namespace PowerLifting.LiftingStats.Contracts
{
    public interface ILiftingStatRepository : IRepositoryBase<LiftingStat>
    {
        /// <summary>
        /// Gets a specific lifting stat rep range for a given user
        /// </summary>
        Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange);

        /// <summary>
        /// Gets the lifting stats associated with a given user
        /// </summary>
        Task<IEnumerable<LiftingStat>> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Used to get a specific lifting stat for deletion or update
        /// </summary>
        Task<LiftingStat> GetLiftingStatById(int liftingStatId);

        /// <summary>
        /// Used to determine if the user already has a lifting stat for this exercise and rep range
        /// </summary>
        Task<LiftingStat> GetLiftingStatByExerciseIdAndRepRange(string userId, int exerciseId, int repRange);

        /// <summary>
        /// Creates a new lifting stat for a given rep range for a specific user
        /// </summary>
        Task CreateLiftingStat(LiftingStat liftingStat);

        /// <summary>
        /// Updates lifting stats for a given user
        /// </summary>
        Task<bool> UpdateLiftingStat(LiftingStat liftingStat);

        /// <summary>
        /// Deletes a given lifting stat
        /// </summary>
        Task<bool> DeleteLiftingStat(LiftingStat liftingStat);
    }
}