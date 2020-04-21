using System.Threading.Tasks;
using PowerLifting.Service.LiftingStats.DTO;

namespace PowerLifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        Task<LiftingStatDTO> GetLiftingStatByUserId(string userId);
        Task UpdateLiftingStats(string userId, LiftingStatDTO stats);
    }
}