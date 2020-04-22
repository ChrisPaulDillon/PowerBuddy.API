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
            var exerciseId = liftingStatsDTO.ExerciseId;
            var repRange = liftingStatsDTO.RepRange;

            var liftingStat = await _repo.LiftingStat.GetLiftingStatByExerciseIdAndRepRange(
                                                      userId, exerciseId, repRange);

            if(liftingStat != null)
            {
                throw new LiftingStatRepRangeAlreadyExistsException();
            }

            var newLiftingStat = _mapper.Map<LiftingStat>(liftingStatsDTO);
            _repo.LiftingStat.CreateLiftingStat(newLiftingStat);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChange = DateTime.Now.Date,
                RepRange = liftingStatsDTO.RepRange,
                ExerciseId = liftingStatsDTO.ExerciseId,
                UserId = liftingStatsDTO.UserId,

            };
            _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
        }

        public async Task<LiftingStatDTO> GetLiftingStatsByUserId(string userId)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            var liftingStatDTO = _mapper.Map<LiftingStatDTO>(liftingStat);
            return liftingStatDTO;
        }

        public async Task UpdateLiftingStat(LiftingStatDTO stats)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(stats.LiftingStatId);

            if (liftingStat == null) throw new LiftingStatNotFoundException("Lifting stat not found");

            //if (liftingStat.UserId != userId)
            //{
            //    throw new UserDoesNotMatchLiftingStatException("You are not authorised to modify these lifting stats!");
            //}

            var liftingStats = _mapper.Map<LiftingStat>(stats);
            _repo.LiftingStat.UpdateLiftingStat(liftingStats);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChange = DateTime.Now.Date,
                RepRange = stats.RepRange,
                UserId = stats.UserId,
                ExerciseId = stats.ExerciseId
            };

            _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
        }

        public async Task DeleteLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(liftingStatDTO.LiftingStatId);

            if (liftingStat == null) throw new LiftingStatNotFoundException("Lifting stat not found");

            var liftingStatToDelete = _mapper.Map<LiftingStat>(liftingStatDTO);
            _repo.LiftingStat.Delete(liftingStatToDelete);
        }
    }
}