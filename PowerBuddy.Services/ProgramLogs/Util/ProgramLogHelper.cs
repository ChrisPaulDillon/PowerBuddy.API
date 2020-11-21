using System;
using System.Collections.Generic;
using System.Linq;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Services.ProgramLogs.Util
{
    public static class ProgramLogHelper
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
                    return Math.Round((decimal) (user1RM * percent * 2), MidpointRounding.AwayFromZero) / 2;
                case WeightProgressionTypeEnum.INCREMENTAL:
                    return 0;
                default:
                    return 0;
            }
        }

        public static Dictionary<int, string> CalculateDayOrder(ProgramLog programLog)
        {
            var programDayOrder = new Dictionary<int, string>();

            var startingDay = programLog.StartDate.DayOfWeek;
            var startingNo = (int)programLog.StartDate.DayOfWeek;

            var counter = 1;
            programDayOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                    {
                        if (programLog.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (programLog.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (programLog.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (programLog.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (programLog.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (programLog.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (programLog.Sunday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
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
                    {
                        if (programLog.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (programLog.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (programLog.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (programLog.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (programLog.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (programLog.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (programLog.Sunday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                }
            }

            return programDayOrder;
        }
    }
}
