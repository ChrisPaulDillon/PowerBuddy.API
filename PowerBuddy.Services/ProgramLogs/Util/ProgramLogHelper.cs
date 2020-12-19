using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Dictionary<int, string> CalculateDayOrder(ProgramLog ProgramLog)
        {
            var ProgramDayOrder = new Dictionary<int, string>();

            var startingDay = ProgramLog.StartDate.DayOfWeek;
            var startingNo = (int)ProgramLog.StartDate.DayOfWeek;

            var counter = 1;
            ProgramDayOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                    {
                        if (ProgramLog.Monday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (ProgramLog.Tuesday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (ProgramLog.Wednesday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (ProgramLog.Thursday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (ProgramLog.Friday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (ProgramLog.Saturday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (ProgramLog.Sunday) ProgramDayOrder.Add(++counter, day.ToString());
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
                        if (ProgramLog.Monday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (ProgramLog.Tuesday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (ProgramLog.Wednesday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (ProgramLog.Thursday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (ProgramLog.Friday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (ProgramLog.Saturday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (ProgramLog.Sunday) ProgramDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                }
            }

            return ProgramDayOrder;
        }
    }
}
