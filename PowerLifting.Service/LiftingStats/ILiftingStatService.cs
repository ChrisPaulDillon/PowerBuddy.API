using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        Task<LiftingStatDTO> GetLiftingStatByUserId(string userId);
        Task UpdateLiftingStatsAsync(string userId, LiftingStatDTO stats);
    }
}