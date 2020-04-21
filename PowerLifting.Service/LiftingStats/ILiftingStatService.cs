using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        Task<LiftingStatDTO> GetLiftingStatByUserId(string userId);

        /// <summary>
        /// Creates a new lifting stat entry for the user for a given rep range.
        /// Checks if the rep range already exists for the user before creating.
        /// </summary>
        /// <param name="liftingStats"></param>
        /// <returns></returns>
        Task CreateLiftingStats(LiftingStatDTO liftingStats);

        Task UpdateLiftingStats(string userId, LiftingStatDTO stats);
    }
}