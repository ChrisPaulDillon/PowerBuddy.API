using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.LiftingStats;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Services.Weights
{
    public interface IWeightOutgoingConvertorService
    {
        Task<decimal> ConvertGenericWeight(decimal weight, string userId, bool? isMetric = null);

        Task<IEnumerable<WorkoutExerciseDto>> ConvertWorkoutExercises(IEnumerable<WorkoutExerciseDto> workoutExercises, string userId, bool? isMetric = null);

        /// <summary>
        /// Converts a workout set to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        Task<WorkoutSetDto> ConvertWorkoutSet(WorkoutSetDto workoutSet, string userId, bool? isMetric = null);

        /// <summary>
        /// Converts a workout set collection to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        Task<IEnumerable<WorkoutSetDto>> ConvertWorkoutSets(IEnumerable<WorkoutSetDto> workoutSets, string userId, bool? isMetric = null);

        Task<IEnumerable<LiftingStatAuditDto>> ConvertPersonalBests(IEnumerable<LiftingStatAuditDto> personalBests, string userId, bool? isMetric = null);
    }
}
