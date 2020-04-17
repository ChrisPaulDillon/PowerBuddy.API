using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

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

        public async Task UpdateLiftingStatsAsync(string userId, LiftingStatDTO stats)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            if (liftingStat == null) throw new LiftingStatNotFoundException("Lifting stat not found");
            if (liftingStat.UserId != userId)
                throw new UserDoesNotMatchLiftingStatException("You are not authorised to modify these lifting stats!");
            var liftingStats = _mapper.Map<LiftingStat>(stats);
            _repo.LiftingStat.UpdateLiftingStats(liftingStats);
        }
    }
}