using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.App.Services.Weights.Models;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.DTOs.WorkoutTemplates;

namespace PowerBuddy.App.Services.Weights
{
    public interface IWeightInsertConvertorService
    {
        Task<WeightInsertResponse<decimal>> ConvertGenericWeightToDbSuitable(string userId, decimal weight);

        Task<IEnumerable<TemplateWeightInputDto>> ConvertWeightInputsToDbSuitable(string userId, IEnumerable<TemplateWeightInputDto> weightInputs);
        Task<WeightInsertResponse<IEnumerable<WorkoutExerciseDto>>> ConvertWorkoutExerciseWeightsToDbSuitable(string userId, IEnumerable<WorkoutExerciseDto> workoutExercises);
        Task<WeightInsertResponse<IEnumerable<WorkoutTemplateExerciseDto>>> ConvertWorkoutTemplateExerciseWeightsToDbSuitable(string userId, IEnumerable<WorkoutTemplateExerciseDto> workoutExercises);

        /// <summary>
        /// Converts a workout set collection into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        Task<WeightInsertResponse<IEnumerable<WorkoutSetDto>>> ConvertWeightSetsToDbSuitable(string userId, IEnumerable<WorkoutSetDto> workoutSets);

        /// <summary>
        /// Converts a single workout set into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        Task<WeightInsertResponse<WorkoutSetDto>> ConvertWeightSetToDbSuitable(string userId, WorkoutSetDto workoutSet);

    }
}
