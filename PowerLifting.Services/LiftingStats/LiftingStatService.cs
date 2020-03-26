using AutoMapper;
using Powerlifting.Service.LiftingStats.Model;
using Powerlifting.Services.ServiceWrappers;

namespace Powerlifting.Service.LiftingStats
{
    public class LiftingStatService : ServiceBase<LiftingStat>, ILiftingStatService
    {
        private IMapper _mapper;

        public LiftingStatService(PowerliftingContext ServiceContext, IMapper mapper)
            : base(ServiceContext)
        {
            _mapper = mapper;
        }

        public void UpdateLiftingStats(LiftingStat stats)
        {
            Update(stats);
        }
    }
}
