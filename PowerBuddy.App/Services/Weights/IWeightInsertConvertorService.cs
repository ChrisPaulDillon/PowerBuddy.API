using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.App.Services.Weights.Models;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.App.Services.Weights
{
    public interface IWeightInsertConvertorService
    {
        Task<WeightInsertResponse<decimal>> ConvertGenericWeightToDbSuitable(string userId, decimal weight);

        Task<IEnumerable<TemplateWeightInputDTO>> ConvertWeightInputsToDbSuitable(string userId, IEnumerable<TemplateWeightInputDTO> weightInputs);
        Task<WeightInsertResponse<WorkoutDayDTO>> ConvertWorkoutDayWeightsToDbSuitable(string userId, WorkoutDayDTO workoutDay);

        /// <summary>
        /// Converts a workout set collection into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        Task<WeightInsertResponse<IEnumerable<WorkoutSetDTO>>> ConvertWeightSetsToDbSuitable(string userId, IEnumerable<WorkoutSetDTO> workoutSets);

        /// <summary>
        /// Converts a single workout set into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        Task<WeightInsertResponse<WorkoutSetDTO>> ConvertWeightSetToDbSuitable(string userId, WorkoutSetDTO workoutSet);

    }
}
