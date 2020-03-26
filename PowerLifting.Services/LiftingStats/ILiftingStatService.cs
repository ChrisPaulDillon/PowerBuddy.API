using Powerlifting.Service.LiftingStats.Model;

namespace Powerlifting.Service.LiftingStats
{
    public interface ILiftingStatService
    {
        void UpdateLiftingStats(LiftingStat stats);
    }
}
