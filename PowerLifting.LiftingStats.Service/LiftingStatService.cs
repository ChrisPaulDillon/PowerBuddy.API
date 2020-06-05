using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.LiftingStats.Service.Exceptions;
using PowerLifting.LiftingStats.Service.Validator;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.LiftingStats.Service
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly IMapper _mapper;
        private readonly ILiftingStatsWrapper _repo;

        public LiftingStatService(ILiftingStatsWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserId(string userId)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
            var liftingStatDTO = _mapper.Map<IEnumerable<LiftingStatDTO>>(liftingStat);
            return liftingStatDTO;
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            var liftingStats = _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, repRange);
            var liftingStatsDTO = _mapper.Map<IEnumerable<LiftingStatDTO>>(liftingStats);
            return liftingStatsDTO;
        }

        public async Task<LiftingStatDTO> CreateLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var userId = liftingStatDTO.UserId;
            var repRange = liftingStatDTO.RepRange;

            var liftingStat = _repo.LiftingStat.GetLiftingStatByExerciseIdAndRepRange(userId, liftingStatDTO.Exercise.ExerciseId, repRange);

            if (liftingStat != null) throw new LiftingStatAlreadyExistsException();

            var createdLiftingStatDTO = new LiftingStatDTO()
            {
                UserId = liftingStatDTO.UserId,
                ExerciseId = liftingStatDTO.ExerciseId,
                RepRange = liftingStatDTO.RepRange,
                Weight = liftingStatDTO.Weight,
                GoalWeight = liftingStatDTO.GoalWeight,
                PercentageToGoal = liftingStatDTO.GoalWeight != null ? (liftingStatDTO.Weight / liftingStatDTO.GoalWeight) * 100 : null,
                LastUpdated = liftingStatDTO.LastUpdated,
                Exercise = liftingStatDTO.Exercise
            };

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