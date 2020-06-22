using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Model;

namespace PowerLifting.LiftingStats.Contracts
{
    public interface ILiftingStatRepository
    {
        /// <summary>
        /// Gets a specific lifting stat rep range for a given user
        /// </summary>
        Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange);

        /// <summary>
        /// Gets the lifting stats associated with a given user
        /// </summary>
        Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Used to get a specific lifting stat for deletion or update
        /// </summary>
        Task<LiftingStat> GetLiftingStatById(int liftingStatId);

        /// <summary>
        /// Checks whether a liftingStat exists or not
        /// </summary>
        Task<bool> DoesLiftingStatExist(int liftingStatId);

        /// <summary>
        /// Used to determine if the user already has a lifting stat for this exercise and rep range
        /// </summary>
        Task<bool> DoesLiftingStatExistByExerciseAndRep(string userId, int exerciseId, int repRange);

        /// <summary>
        /// Creates a new lifting stat for a given rep range for a specific user
        /// </summary>
        Task<LiftingStat> CreateLiftingStat(LiftingStatDTO liftingStat);

        /// <summary>
        /// Used for batch creation
        /// </summary>
        void CreateLiftingStatNoSave(LiftingStat liftingStat);

        /// <summary>
        /// Updates lifting stats for a given user
        /// </summary>
        Task<bool> UpdateLiftingStat(LiftingStatDTO liftingStat);

        /// <summary>
        /// Deletes a given lifting stat
        /// </summary>
        Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatId);

        Task<bool> SaveChangesAsync();
    }
}