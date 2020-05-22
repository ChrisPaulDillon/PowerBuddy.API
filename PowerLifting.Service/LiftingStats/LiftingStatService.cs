﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Service.LiftingStats.DTO;
using PowerLifting.Service.LiftingStats.Model;
using PowerLifting.Service.LiftingStats.Validators;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.Service.LiftingStats
{
    public class LiftingStatService : ILiftingStatService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;
        private readonly LiftingStatValidator _validator;

        public LiftingStatService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _validator = new LiftingStatValidator();
        }

        public void CreateLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var userId = liftingStatDTO.UserId;
            var exerciseId = liftingStatDTO.ExerciseId;
            var repRange = liftingStatDTO.RepRange;

            liftingStatDTO.Exercise = null;

            var liftingStat = _repo.LiftingStat.GetLiftingStatByExerciseIdAndRepRange(userId, exerciseId, repRange);

            _validator.ValidateLiftingStatDoesNotAlreadyExist(liftingStat);

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
            _validator.ValidateLiftingStatId(stats.LiftingStatId);
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(stats.LiftingStatId);
            _validator.ValidateLiftingStatExists(liftingStat);

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
            _validator.ValidateLiftingStatId(liftingStatId);
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(liftingStatId);
            _validator.ValidateLiftingStatExists(liftingStat);

            _repo.LiftingStat.Delete(liftingStat);
        }
    }
}