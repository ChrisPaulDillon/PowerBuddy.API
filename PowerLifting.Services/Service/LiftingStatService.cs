using System.Threading.Tasks;
using AutoMapper;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Entities.Model;
using PowerLifting.Persistence;

namespace Powerlifting.Services.Service
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
