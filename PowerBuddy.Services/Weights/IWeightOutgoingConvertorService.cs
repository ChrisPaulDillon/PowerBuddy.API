using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.LiftingStats;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.Services.Weights
{
    public interface IWeightOutgoingConvertorService
    {
        Task<decimal> ConvertGenericWeight(decimal weight, string userId, bool? isMetric = null);

        Task<WorkoutDayDTO> ConvertWorkoutDay(WorkoutDayDTO workoutSet, string userId, bool? isMetric = null);

        /// <summary>
        /// Converts a workout set to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        Task<WorkoutSetDTO> ConvertWorkoutSet(WorkoutSetDTO workoutSet, string userId, bool? isMetric = null);

        /// <summary>
        /// Converts a workout set collection to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        Task<IEnumerable<WorkoutSetDTO>> ConvertWorkoutSets(IEnumerable<WorkoutSetDTO> workoutSets, string userId, bool? isMetric = null);

        Task<IEnumerable<LiftingStatAuditDTO>> ConvertPersonalBests(IEnumerable<LiftingStatAuditDTO> personalBests, string userId, bool? isMetric = null);
    }
}
