using AutoMapper;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Services.LiftingStats;

namespace Powerlifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private IMapper _mapper;
        private ILiftingStatRepository _liftingStatRepo;

        public LiftingStatService(ILiftingStatRepository liftingStatRepo, IMapper mapper)
        {
            _liftingStatRepo = liftingStatRepo;
            _mapper = mapper;
        }

        public void UpdateLiftingStats(LiftingStat stats)
        {
            //Update(stats);
        }
    }
}
