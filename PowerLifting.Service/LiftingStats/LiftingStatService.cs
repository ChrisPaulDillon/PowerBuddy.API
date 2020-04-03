using System.Threading.Tasks;
using AutoMapper;
using Powerlifting.Service.LiftingStats.DTO;
using Powerlifting.Service.LiftingStats.Model;
using PowerLifting.Service.ServiceWrappers;

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

        public async Task<LiftingStatDTO> GetLiftingStatByUserId(string userId)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            var liftingStatDTO = _mapper.Map<LiftingStatDTO>(liftingStat);
            return liftingStatDTO;
        }

        public void UpdateLiftingStats(LiftingStatDTO stats)
        {
            var liftingStats = _mapper.Map<LiftingStat>(stats);
            _repo.LiftingStat.UpdateLiftingStats(liftingStats);
        }
    }
}
