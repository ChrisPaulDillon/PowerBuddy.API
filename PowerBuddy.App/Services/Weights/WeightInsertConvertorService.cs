using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Weights.Models;
using PowerBuddy.App.Services.Weights.Util;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Services.Weights
{
    public class WeightInsertConvertorService : IWeightInsertConvertorService
    {
        private readonly PowerLiftingContext _context;

        public WeightInsertConvertorService(PowerLiftingContext context)
        {
            _context = context;
        }

        private async Task<bool> IsUserUsingMetric(string userId)
        {
            return await _context.User
                .AsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => x.UserSetting.UsingMetric)
                .FirstOrDefaultAsync();
        }

        #region Generic

        public async Task<WeightInsertResponse<decimal>> ConvertGenericWeightToDbSuitable(string userId, decimal weight)
        {
            var isMetric = await IsUserUsingMetric(userId);
            if (isMetric)
            {
                return WeightInsertResponse<decimal>.UsingMetric(weight);
            }
            weight = WeightConversionHelper.ConvertWeightToKiloInsert(weight);
            return WeightInsertResponse<decimal>.NotMetric(weight);
        }

        #endregion


        #region Workouts

        public async Task<IEnumerable<TemplateWeightInputDto>> ConvertWeightInputsToDbSuitable(string userId, IEnumerable<TemplateWeightInputDto> weightInputs)
        {
            var isMetric = await IsUserUsingMetric(userId);
            if (isMetric)
            {
                return weightInputs;
            }

            foreach (var weightInput in weightInputs)
            {
                if (weightInput.Weight != null)
                {
                    weightInput.Weight = WeightConversionHelper.ConvertWeightToKiloInsert((decimal)weightInput.Weight);
                }
            }

            return weightInputs;
        }

        public async Task<WeightInsertResponse<WorkoutDayDto>> ConvertWorkoutDayWeightsToDbSuitable(string userId, WorkoutDayDto workoutDay)
        {
            var isMetric = await IsUserUsingMetric(userId);
            if (isMetric)
            {
                return WeightInsertResponse<WorkoutDayDto>.UsingMetric(workoutDay);
            }

            foreach (var workoutExercise in workoutDay.WorkoutExercises)
            {
                foreach (var workoutSet in workoutExercise.WorkoutSets)
                {
                    workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
                }
            }

            return WeightInsertResponse<WorkoutDayDto>.NotMetric(workoutDay);
        }

        public async Task<WeightInsertResponse<IEnumerable<WorkoutSetDto>>> ConvertWeightSetsToDbSuitable(string userId, IEnumerable<WorkoutSetDto> workoutSets)
        {
            var isMetric = await IsUserUsingMetric(userId);

            if (isMetric)
            {
                return WeightInsertResponse<IEnumerable<WorkoutSetDto>>.UsingMetric(workoutSets);
            }

            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
            }

            return WeightInsertResponse<IEnumerable<WorkoutSetDto>>.NotMetric(workoutSets);
        }

        public async Task<WeightInsertResponse<WorkoutSetDto>> ConvertWeightSetToDbSuitable(string userId, WorkoutSetDto workoutSet)
        {
            var isMetric = await IsUserUsingMetric(userId);

            if (isMetric)
            {
                return WeightInsertResponse<WorkoutSetDto>.UsingMetric(workoutSet);
            }

            workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
            return WeightInsertResponse<WorkoutSetDto>.NotMetric(workoutSet);
        }

        #endregion
    }
}
