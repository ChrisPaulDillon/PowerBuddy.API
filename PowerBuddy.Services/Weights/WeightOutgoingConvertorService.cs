using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Weights.Util;

namespace PowerBuddy.Services.Weights
{
    public class WeightOutgoingConvertorService : IWeightOutgoingConvertorService
    {
        private readonly IAccountService _accountService;

        public WeightOutgoingConvertorService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<decimal> ConvertGenericWeight(decimal weight, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            return (bool)isMetric
                        ? WeightConversionHelper.ConvertWeightToKiloOutgoing(weight)
                        : WeightConversionHelper.ConvertWeightToPoundsOutgoing(weight);
        }

        public async Task<WorkoutDayDTO> ConvertWorkoutDay(WorkoutDayDTO workoutDay, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            foreach (var workoutExercise in workoutDay.WorkoutExercises)
            {
                foreach (var workoutSet in workoutExercise.WorkoutSets)
                {
                    workoutSet.WeightLifted = (bool)isMetric
                        ? WeightConversionHelper.ConvertWeightToKiloOutgoing(workoutSet.WeightLifted)
                        : WeightConversionHelper.ConvertWeightToPoundsOutgoing(workoutSet.WeightLifted);
                }
            }

            return workoutDay;
        }

        public async Task<WorkoutSetDTO> ConvertWorkoutSet(WorkoutSetDTO workoutSet, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            workoutSet.WeightLifted = (bool)isMetric ? WeightConversionHelper.ConvertWeightToKiloOutgoing(workoutSet.WeightLifted) : WeightConversionHelper.ConvertWeightToPoundsOutgoing(workoutSet.WeightLifted);
            return workoutSet;
        }

        public async Task<IEnumerable<WorkoutSetDTO>> ConvertWorkoutSets(IEnumerable<WorkoutSetDTO> workoutSets, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = (bool) isMetric
                    ? WeightConversionHelper.ConvertWeightToKiloOutgoing(workoutSet.WeightLifted)
                    : WeightConversionHelper.ConvertWeightToPoundsOutgoing(workoutSet.WeightLifted);
            }

            return workoutSets;
            
        }

        public async Task<IEnumerable<LiftingStatAuditDTO>> ConvertPersonalBests(IEnumerable<LiftingStatAuditDTO> personalBests, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            foreach (var personalBest in personalBests)
            {
                personalBest.Weight = (bool) isMetric
                    ? WeightConversionHelper.ConvertWeightToKiloOutgoing(personalBest.Weight)
                    : WeightConversionHelper.ConvertWeightToPoundsOutgoing(personalBest.Weight);
            }

            return personalBests;
        }
    }
}
