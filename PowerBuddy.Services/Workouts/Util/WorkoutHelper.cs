using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.Workouts.Util
{
    public static class WorkoutHelper
    {
        public static decimal CalculateTonnage(decimal weight, int reps)
        {
            return weight * reps;
        }

        public static decimal CalculateRepSchemeWeight(WeightProgressionTypeEnum weightProgressionType, decimal user1RM, TemplateRepSchemeDTO templateRepScheme)
        {
            switch (weightProgressionType)
            {
                case WeightProgressionTypeEnum.PERCENTAGE:
                    var percent = templateRepScheme.Percentage / 100;
                    return Math.Round((decimal)(user1RM * percent * 2), MidpointRounding.AwayFromZero) / 2;
                case WeightProgressionTypeEnum.INCREMENTAL:
                    return 0;
                default:
                    return 0;
            }
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
