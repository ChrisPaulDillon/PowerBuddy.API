using System.Threading.Tasks;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;

namespace Powerlifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        Task<LiftingStatDTO> GetLiftingStatByUserId(string userId);
        void UpdateLiftingStats(LiftingStatDTO stats);
    }
}
