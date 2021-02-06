using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.App.Services.Account;
using PowerBuddy.App.Services.Weights.Util;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Services.Weights
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

        public async Task<IEnumerable<WorkoutExerciseDto>> ConvertWorkoutExercises(IEnumerable<WorkoutExerciseDto> workoutExercises, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            foreach (var workoutExercise in workoutExercises)
            {
                foreach (var workoutSet in workoutExercise.WorkoutSets)
                {
                    workoutSet.WeightLifted = (bool)isMetric
                        ? WeightConversionHelper.ConvertWeightToKiloOutgoing(workoutSet.WeightLifted)
                        : WeightConversionHelper.ConvertWeightToPoundsOutgoing(workoutSet.WeightLifted);
                }
            }

            return workoutExercises;
        }

        public async Task<WorkoutSetDto> ConvertWorkoutSet(WorkoutSetDto workoutSet, string userId, bool? isMetric = null)
        {
            isMetric ??= await _accountService.IsUserUsingMetric(userId);

            workoutSet.WeightLifted = (bool)isMetric ? WeightConversionHelper.ConvertWeightToKiloOutgoing(workoutSet.WeightLifted) : WeightConversionHelper.ConvertWeightToPoundsOutgoing(workoutSet.WeightLifted);
            return workoutSet;
        }

        public async Task<IEnumerable<WorkoutSetDto>> ConvertWorkoutSets(IEnumerable<WorkoutSetDto> workoutSets, string userId, bool? isMetric = null)
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

        public async Task<IEnumerable<LiftingStatAuditDto>> ConvertPersonalBests(IEnumerable<LiftingStatAuditDto> personalBests, string userId, bool? isMetric = null)
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
