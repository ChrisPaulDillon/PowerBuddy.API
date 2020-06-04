using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.RepositoryMediator;
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

        public async Task<LiftingStatDTO> CreateLiftingStat(CreateLiftingStatDTO createLiftingStatDTO)
        {
            var userId = createLiftingStatDTO.UserId;
            var exerciseName = createLiftingStatDTO.ExerciseName;
            var repRange = createLiftingStatDTO.RepRange;

            var exercise = await _repo.Exercise.GetExerciseByName(exerciseName);
            var liftingStat = _repo.LiftingStat.GetLiftingStatByExerciseIdAndRepRange(userId, exercise.ExerciseId, repRange);

            if (liftingStat != null) throw new LiftingStatAlreadyExistsException();

            var liftingStatDTO = new LiftingStatDTO()
            {
                UserId = createLiftingStatDTO.UserId,
                ExerciseId = exercise.ExerciseId,
                RepRange = createLiftingStatDTO.RepRange,
                Weight = createLiftingStatDTO.Weight,
                GoalWeight = createLiftingStatDTO.GoalWeight,
                PercentageToGoal = createLiftingStatDTO.GoalWeight != null ? (createLiftingStatDTO.Weight / createLiftingStatDTO.GoalWeight) * 100 : null,
                LastUpdated = createLiftingStatDTO.LastUpdated,
                Exercise = _mapper.Map<ExerciseDTO>(exercise)
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