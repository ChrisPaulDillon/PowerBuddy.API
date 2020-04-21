using System;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStatsAudit.Model;
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

        public async Task CreateLiftingStats(LiftingStatDTO liftingStatsDTO)
        {
            var userId = liftingStatsDTO.UserId;
            var repRange = liftingStatsDTO.RepRange;

            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, repRange);

            if(liftingStat != null)
            {
                throw new LiftingStatRepRangeAlreadyExistsException();
            }

            var newLiftingStat = _mapper.Map<LiftingStat>(liftingStatsDTO);
            _repo.LiftingStat.CreateLiftingStat(newLiftingStat);
        }

        public async Task<LiftingStatDTO> GetLiftingStatByUserId(string userId)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            var liftingStatDTO = _mapper.Map<LiftingStatDTO>(liftingStat);
            return liftingStatDTO;
        }

        public async Task UpdateLiftingStats(string userId, LiftingStatDTO stats)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);

            if (liftingStat == null) throw new LiftingStatNotFoundException("Lifting stat not found");

            if (liftingStat.UserId != userId)
            {
                throw new UserDoesNotMatchLiftingStatException("You are not authorised to modify these lifting stats!");
            }

            var liftingStats = _mapper.Map<LiftingStat>(stats);
            _repo.LiftingStat.UpdateLiftingStats(liftingStats);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChange = DateTime.Now.Date,
                RepRange = stats.RepRange,
                UserId = stats.UserId,

            };

            _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
        }
    }
}