using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Exceptions;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStats.Validators;
using PowerLifting.Service.LiftingStatsAudit.Model;

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

        public void CreateLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var userId = liftingStatDTO.UserId;
            var exerciseId = liftingStatDTO.ExerciseId;
            var repRange = liftingStatDTO.RepRange;

            liftingStatDTO.Exercise = null;

            var liftingStat = _repo.LiftingStat.GetLiftingStatByExerciseIdAndRepRange(userId, exerciseId, repRange);

            if (liftingStat != null) throw new LiftingStatAlreadyExistsException();

            if (liftingStatDTO.GoalWeight != null)
            {
                liftingStatDTO.PercentageToGoal = (liftingStatDTO.Weight / liftingStatDTO.GoalWeight) * 100;
            }

            var newLiftingStat = _mapper.Map<LiftingStat>(liftingStatDTO);
            _repo.LiftingStat.CreateLiftingStat(newLiftingStat);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.Now.Date,
                RepRange = liftingStatDTO.RepRange,
                ExerciseId = liftingStatDTO.ExerciseId,
                UserId = liftingStatDTO.UserId,
            };
            _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            var liftingStatDTO = _mapper.Map<IEnumerable<LiftingStatDTO>>(liftingStat);
            return liftingStatDTO;
        }

        public async Task UpdateLiftingStat(LiftingStatDTO stats)
        {
            var validator = new LiftingStatValidator();
            validator.ValidateLiftingStatId(stats.LiftingStatId);

            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(stats.LiftingStatId);
            if (liftingStat == null) throw new LiftingStatNotFoundException();

            var liftingStats = _mapper.Map<LiftingStat>(stats);
            _repo.LiftingStat.UpdateLiftingStat(liftingStats);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.Now.Date,
                RepRange = stats.RepRange,
                UserId = stats.UserId,
                ExerciseId = stats.ExerciseId
            };

            _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
        }

        public async Task DeleteLiftingStat(int liftingStatId)
        {
            var validator = new LiftingStatValidator();
            validator.ValidateLiftingStatId(liftingStatId);

            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(liftingStatId);
            if (liftingStat == null) throw new LiftingStatNotFoundException();

            _repo.LiftingStat.Delete(liftingStat);
        }
    }
}