using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.WeightHelper;

namespace PowerBuddy.Services.Weights
{
    public class WeightService : IWeightService
    {
        public WorkoutSetDTO ConvertReturnedWorkoutSet(bool isMetric, WorkoutSetDTO workoutSet)
        {
            if (isMetric)
            {
                return ConvertSingleReturnedWorkoutSetToKg(workoutSet);
            }
            else
            {
                return ConvertSingleReturnedWorkoutSetToPounds(workoutSet);
            }
        }

        public IEnumerable<WorkoutSetDTO> ConvertReturnedWorkoutSets(bool isMetric, IEnumerable<WorkoutSetDTO> workoutSets)
        {
            if (isMetric)
            {
                return ConvertReturnedWeightSetsToKg(workoutSets);
            }
            else
            {
                return ConvertReturnedSetsToPounds(workoutSets);
            }
        }

        public IEnumerable<WorkoutSet> ConvertInsertWeightSetsToDbSuitable(bool isMetric, IEnumerable<WorkoutSet> workoutSets)
        {
            if (isMetric)
            {
                return workoutSets;
            }

            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKg(workoutSet.WeightLifted);
            }

            return workoutSets;
        }

        public WorkoutSet ConvertInsertWeightSetToDbSuitable(bool isMetric, WorkoutSet workoutSet)
        {
            if (isMetric)
            {
                return workoutSet;
            }

            workoutSet.WeightLifted = WeightConversionHelper.ConvertWeightToKg(workoutSet.WeightLifted);
            return workoutSet;
        }

        #region Private Methods

        private static WorkoutSetDTO ConvertSingleReturnedWorkoutSetToPounds(WorkoutSetDTO workoutSet)
        {
            workoutSet.WeightLifted = WeightConversionHelper.RoundWeightToNearestQuarter(WeightConversionHelper.ConvertWeightToPounds(workoutSet.WeightLifted));
            return workoutSet;
        }

        private static IEnumerable<WorkoutSetDTO> ConvertReturnedSetsToPounds(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConversionHelper.RoundWeightToNearestQuarter(WeightConversionHelper.ConvertWeightToPounds(workoutSet.WeightLifted));
            }

            return workoutSets;
        }

        private static WorkoutSetDTO ConvertSingleReturnedWorkoutSetToKg(WorkoutSetDTO workoutSet)
        {
            workoutSet.WeightLifted = WeightConversionHelper.RoundWeightToNearestQuarter(workoutSet.WeightLifted);
            return workoutSet;
        }

        private static IEnumerable<WorkoutSetDTO> ConvertReturnedWeightSetsToKg(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConversionHelper.RoundWeightToNearestQuarter(workoutSet.WeightLifted);
            }

            return workoutSets;
        }

        #endregion
    }
}
