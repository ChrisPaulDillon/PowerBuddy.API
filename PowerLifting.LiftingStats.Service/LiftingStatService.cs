﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.LiftingStats.Contracts;
using PowerLifting.LiftingStats.Service.Exceptions;
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
            return await _repo.LiftingStat.GetLiftingStatsByUserId(userId);
        }

        public async Task<IEnumerable<LiftingStatDTO>> GetLiftingStatsByUserIdAndRepRange(string userId, int repRange)
        {
            var liftingStats = await _repo.LiftingStat.GetLiftingStatsByUserIdAndRepRange(userId, repRange);
            var liftingStatsDTO = _mapper.Map<IEnumerable<LiftingStatDTO>>(liftingStats);
            return liftingStatsDTO;
        }

        public async Task<bool> CreateLiftingStatsByAthleteType(string userId, IEnumerable<TopLevelExerciseDTO> exercises)
        {
            var repRanges = new int[] { 1, 2, 3, 5, 10 };
            var exerciseList = exercises.ToList();
            foreach (var exercise in exerciseList)
            {
                foreach (var repRange in repRanges)
                {
                    _repo.LiftingStat.CreateLiftingStatNoSave(
                        new LiftingStat()
                        {
                            UserId = userId,
                            ExerciseId = exercise.ExerciseId,
                            RepRange = repRange,
                            LastUpdated = null
                        });
                }
            }
            return await _repo.LiftingStat.SaveChangesAsync();
        }

        public async Task<LiftingStat> CreateLiftingStat(LiftingStatDTO liftingStatDTO)
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

            var liftingStatEntity = await _repo.LiftingStat.CreateLiftingStat(createdLiftingStatDTO);

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.Now.Date,
                RepRange = liftingStatDTO.RepRange,
                ExerciseId = liftingStatDTO.ExerciseId,
                UserId = liftingStatDTO.UserId,
            };
            await _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
            return liftingStatEntity;
        }

        public async Task<bool> UpdateLiftingStat(LiftingStatDTO stats)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(stats.LiftingStatId);
            if (liftingStat == null) throw new LiftingStatNotFoundException();

            var liftingStatAudit = new LiftingStatAudit()
            {
                DateChanged = DateTime.Now.Date,
                RepRange = stats.RepRange,
                UserId = stats.UserId,
                ExerciseId = stats.ExerciseId
            };

            await _repo.LiftingStatAudit.CreateLiftingStatAudit(liftingStatAudit);
            return await _repo.LiftingStat.UpdateLiftingStat(stats);
        }

        public async Task<bool> DeleteLiftingStat(LiftingStatDTO liftingStatDTO)
        {
            var liftingStat = await _repo.LiftingStat.GetLiftingStatById(liftingStatDTO.LiftingStatId);
            if (liftingStat == null) throw new LiftingStatNotFoundException();

            return await _repo.LiftingStat.DeleteLiftingStat(liftingStatDTO);
        }
    }
}