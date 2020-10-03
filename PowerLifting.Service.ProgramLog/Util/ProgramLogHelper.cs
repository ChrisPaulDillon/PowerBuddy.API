using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Service.ProgramLogs.Util
{
    public static class ProgramLogHelper
    {
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

        public static Dictionary<int, string> CalculateDayOrder(CProgramLogDTO programLogDTO)
        {
            var programDayOrder = new Dictionary<int, string>();

            var startingDay = programLogDTO.StartDate.DayOfWeek;
            var startingNo = (int)programLogDTO.StartDate.DayOfWeek;

            var counter = 1;
            programDayOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                    {
                        if (programLogDTO.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (programLogDTO.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (programLogDTO.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (programLogDTO.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (programLogDTO.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (programLogDTO.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (programLogDTO.Sunday) programDayOrder.Add(++counter, day.ToString());
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
                        if (programLogDTO.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (programLogDTO.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (programLogDTO.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (programLogDTO.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (programLogDTO.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (programLogDTO.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (programLogDTO.Sunday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                }
            }

            return programDayOrder;
        }
    }
}
