using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        /// <summary>
        /// Gets all lifting stats associated with a user.
        /// This 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<LiftingStatDTO> GetLiftingStatsByUserId(string userId);

        /// <summary>
        /// Creates a new lifting stat entry for the user for a given rep range.
        /// Checks if the rep range already exists for the user before creating.
        /// </summary>
        /// <param name="liftingStats"></param>
        /// <returns></returns>
        Task CreateLiftingStats(LiftingStatDTO liftingStats);

        /// <summary>
        /// Updates a given lifting stat and logs the new result
        /// and date in the liftingstataudit table
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="stats"></param>
        /// <returns></returns>
        Task UpdateLiftingStat(LiftingStatDTO liftingStatDTO);

        /// <summary>
        /// Deletes a given lifting stat and the audit associated with it
        /// </summary>
        /// <param name="liftingStatDTO"></param>
        /// <returns></returns>
        Task DeleteLiftingStat(LiftingStatDTO liftingStatDTO);
    }
}