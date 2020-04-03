using System.Threading.Tasks;
using Powerlifting.Service.LiftingStats.DTO;

namespace Powerlifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        Task<LiftingStatDTO> GetLiftingStatByUserId(string userId);
        Task UpdateLiftingStatsAsync(string userId, LiftingStatDTO stats);
    }
}
