using System.Threading.Tasks;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ServiceWrappers;
using PowerLifting.Entities.Model;

namespace Powerlifting.Service.LiftingStats
{
    public interface ILiftingStatService : IServiceBase<LiftingStat>
    {
        void UpdateLiftingStats(LiftingStat stats);
    }
}
