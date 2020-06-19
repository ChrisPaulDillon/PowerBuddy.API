using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.LiftingStats.Service
{
    public interface ILiftingStatService
    {
        /// <summary>
        /// Gets all lifting stats associated with a user.
        /// </summary>
        Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId);

        Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange);

        /// <summary>
        /// Creates a new lifting stat entry for the user for a given rep range.
        /// Checks if the rep range already exists for the user before creating.
        /// </summary>
        Task<LiftingStatDTO> CreateLiftingStat(LiftingStatDTO liftingStats);

        /// <summary>
        /// Updates a given lifting stat and logs the new result
        /// and date in the liftingstataudit table
        /// </summary>
        Task<bool> UpdateLiftingStat(LiftingStatDTO liftingStatDTO);

        /// <summary>
        /// Deletes a given lifting stat and the audit associated with it
        /// </summary>
        Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatId);
    }
}