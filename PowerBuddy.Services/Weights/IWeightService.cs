using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.Weights
{
    public interface IWeightService
    {
        /// <summary>
        /// Converts a workout set to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        WorkoutSetDTO ConvertReturnedWorkoutSet(bool isMetric, WorkoutSetDTO workoutSet);

        /// <summary>
        /// Converts a workout set collection to it's correct format to be displayed to the user
        /// based on the users preference for lbs or kg
        /// </summary>
        IEnumerable<WorkoutSetDTO> ConvertReturnedWorkoutSets(bool isMetric, IEnumerable<WorkoutSetDTO> workoutSets);

        /// <summary>
        /// Converts a workout set collection into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        IEnumerable<WorkoutSet> ConvertInsertWeightSetsToDbSuitable(bool isMetric, IEnumerable<WorkoutSet> workoutSets);

        /// <summary>
        /// Converts a single workout set into a db suitable format. If the users preference is metric, no modifications
        /// are made. If the user is in lbs, the weight is converted to raw kg with no rounding
        /// </summary>
        WorkoutSet ConvertInsertWeightSetToDbSuitable(bool isMetric, WorkoutSet workoutSet);

    }
}
