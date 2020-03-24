using System.Threading.Tasks;
using PowerLifting.Entities.Model;

namespace Powerlifting.Contracts.Contracts
{
    public interface ILiftingStatService : IServiceBase<LiftingStat>
    {
        void UpdateLiftingStats(LiftingStat stats);
        Task<LiftingStat> GetLiftingStatsByIdAsync(int id);
    }
}
