using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Util.Workouts;

namespace PowerBuddy.Services.Workouts.Util
{
    public static class WorkoutHelper
    {
        public static decimal CalculateTonnage(decimal weight, int reps)
        {
            return weight * reps;
        }

        public static WorkoutSetDTO ConvertReturnedWorkoutSet(bool isMetric, WorkoutSetDTO workoutSet)
        {
            if (isMetric)
            {
                workoutSet.WeightLifted = WeightConvertorHelper.RoundWeightToNearestQuarter(workoutSet.WeightLifted);
            }
            else
            {
                workoutSet.WeightLifted = WeightConvertorHelper.RoundWeightToNearestQuarter(WeightConvertorHelper.ConvertWeightToPounds(workoutSet.WeightLifted));
            }

            return workoutSet;
        }

        public static IEnumerable<WorkoutSetDTO> ConvertReturnedWorkoutSets(bool isMetric, IEnumerable<WorkoutSetDTO> workoutSets)
        {
            return isMetric ? ConvertReturnedWeightSetsToKg(workoutSets) : ConvertReturnedSetsToPounds(workoutSets);
        }

        /// <summary>
        /// Used to convert weights to pounds to show to the user if they are using lbs
        /// </summary>
        /// <param name="workoutSets"></param>
        /// <returns></returns>
        private static IEnumerable<WorkoutSetDTO> ConvertReturnedSetsToPounds(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConvertorHelper.RoundWeightToNearestQuarter(WeightConvertorHelper.ConvertWeightToPounds(workoutSet.WeightLifted));
            }

            return workoutSets;
        }

        /// <summary>
        /// Used to round existing kg weights in db. These should normally return the same value but may vary if
        /// the user has inserted weights from the pounds perspective
        /// </summary>
        /// <param name="workoutSets"></param>
        /// <returns></returns>
        private static IEnumerable<WorkoutSetDTO> ConvertReturnedWeightSetsToKg(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConvertorHelper.RoundWeightToNearestQuarter(workoutSet.WeightLifted);
            }

            return workoutSets;
        }

        /// <summary>
        /// Used to convert weights back into Kg before Db insert
        /// </summary>
        /// <param name="workoutSets"></param>
        /// <returns></returns>
        public static IEnumerable<WorkoutSetDTO> ConvertInsertWeightSetsToKg(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            foreach (var workoutSet in workoutSets)
            {
                workoutSet.WeightLifted = WeightConvertorHelper.ConvertWeightToKg(workoutSet.WeightLifted);
            }

            return workoutSets;
        }

        public static Dictionary<int, string> CalculateDayOrder(WorkoutLog Workout)
        {
            var programDayOrder = new Dictionary<int, string>();

            var startingDay = Workout.StartDate.DayOfWeek;
            var startingNo = (int)Workout.StartDate.DayOfWeek;

            var counter = 1;
            programDayOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                        if (Workout.Monday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Tuesday:
                        if (Workout.Tuesday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Wednesday:
                        if (Workout.Wednesday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Thursday:
                        if (Workout.Thursday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Friday:
                        if (Workout.Friday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Saturday:
                        if (Workout.Saturday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Sunday:
                        if (Workout.Sunday) programDayOrder.Add(++counter, day.ToString());
                            break;
                }
            }

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList())
            {
                var dayNo = (int)day;

                if (dayNo >= startingNo) //Once we get to the day we originally started on, stop
                    break;

                switch (day)
                {
                    case DayOfWeek.Monday:
                        if (Workout.Monday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Tuesday:
                        if (Workout.Tuesday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Wednesday:
                        if (Workout.Wednesday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Thursday:
                        if (Workout.Thursday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Friday:
                        if (Workout.Friday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Saturday:
                        if (Workout.Saturday) programDayOrder.Add(++counter, day.ToString());
                            break;
                    case DayOfWeek.Sunday:
                        if (Workout.Sunday) programDayOrder.Add(++counter, day.ToString());
                            break;
                }
            }

            return programDayOrder;
        }
    }
}
