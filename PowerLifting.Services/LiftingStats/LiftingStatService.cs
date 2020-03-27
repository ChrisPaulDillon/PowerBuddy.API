using AutoMapper;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Repositorys.RepositoryWrappers;
using PowerLifting.Services.LiftingStats;

namespace Powerlifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public LiftingStatService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void UpdateLiftingStats(LiftingStat stats)
        {
            //Update(stats);
        }
    }
}
