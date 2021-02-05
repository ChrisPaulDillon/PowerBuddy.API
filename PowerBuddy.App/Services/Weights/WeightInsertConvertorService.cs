using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Weights.Models;
using PowerBuddy.App.Services.Weights.Util;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;

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

        public async Task<IEnumerable<TemplateWeightInputDTO>> ConvertWeightInputsToDbSuitable(string userId, IEnumerable<TemplateWeightInputDTO> weightInputs)
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

        public async Task<WeightInsertResponse<WorkoutDayDTO>> ConvertWorkoutDayWeightsToDbSuitable(string userId, WorkoutDayDTO workoutDay)
        {
            var isMetric = await IsUserUsingMetric(userId);
            if (isMetric)
            {
                return WeightInsertResponse<WorkoutDayDTO>.UsingMetric(workoutDay);
            }

            foreach (var workoutExercise in workoutDay.WorkoutExercises)
            {
                foreach (var workoutSet in workoutExercise.WorkoutSets)
                {
                    workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
                }
            }

            return WeightInsertResponse<WorkoutDayDTO>.NotMetric(workoutDay);
        }

        public async Task<WeightInsertResponse<IEnumerable<WorkoutSetDTO>>> ConvertWeightSetsToDbSuitable(string userId, IEnumerable<WorkoutSetDTO> workoutSets)
        {
            var isMetric = await IsUserUsingMetric(userId);

            if (isMetric)
            {
                return WeightInsertResponse<IEnumerable<WorkoutSetDTO>>.UsingMetric(workoutSets);
            }

            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
            }

            return WeightInsertResponse<IEnumerable<WorkoutSetDTO>>.NotMetric(workoutSets);
        }

        public async Task<WeightInsertResponse<WorkoutSetDTO>> ConvertWeightSetToDbSuitable(string userId, WorkoutSetDTO workoutSet)
        {
            var isMetric = await IsUserUsingMetric(userId);

            if (isMetric)
            {
                return WeightInsertResponse<WorkoutSetDTO>.UsingMetric(workoutSet);
            }

            workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKiloInsert(workoutSet.WeightLifted);
            return WeightInsertResponse<WorkoutSetDTO>.NotMetric(workoutSet);
        }

        #endregion
    }
}
