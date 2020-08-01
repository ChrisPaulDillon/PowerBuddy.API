using System.Collections.Generic;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.System;
using PowerLifting.Data.Entities.Account;

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
        /// Creates a batch of lifting stats based on the users sport preferences
        /// </summary>
        Task<bool> CreateLiftingStatsByAthleteType(string userId, IEnumerable<TopLevelExerciseDTO> exercises);

        /// <summary>
        /// Updates a given lifting stat and logs the new result
        /// and date in the liftingstataudit table
        /// </summary>
        Task<bool> UpdateLiftingStat(LiftingStatDTO liftingStatDTO);

        /// <summary>
        /// Updates an entire lifting stat collection for one exercise
        /// </summary>
        Task<bool> UpdateLiftingStatCollection(IEnumerable<LiftingStatDTO> liftingStatCollectionDTO);

        /// <summary>
        /// Deletes a given lifting stat and the audit associated with it
        /// </summary>
        Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatId);
    }
}