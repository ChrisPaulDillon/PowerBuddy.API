using PowerLifting.Data.DTOs.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Common.Util
{
    public static class ProgramLogHelper
    {
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

        public static IEnumerable<ProgramLogWeekDTO> GenerateProgramWeekDates(CProgramLogDTO programLogDTO, TemplateProgramDTO tp, IList<LiftingStat> liftingStats, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeekWithDays = CreateProgramLogWeek(programLogDTO, templateWeek, liftingStats, userId);
                listOfProgramWeeks.Add(programLogWeekWithDays);
                programLogDTO.StartDate = programLogDTO.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        public static ProgramLogWeekDTO CreateProgramLogWeek(CProgramLogDTO programLogDTO, TemplateWeekDTO templateWeek, IEnumerable<LiftingStat> liftingStats, string userId)
        {
            var programLogWeek = new ProgramLogWeekDTO()
            {
                StartDate = programLogDTO.StartDate,
                EndDate = programLogDTO.StartDate.AddDays(7),
                WeekNo = templateWeek.WeekNo,
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDayDTO>()
            };

            var startDate = programLogWeek.StartDate;
            foreach (var templateDay in templateWeek.TemplateDays)
            {
                var dayOfWeek = programLogDTO.ProgramDayOrder[templateDay.DayNo];
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Monday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    //programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Tuesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    //programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Wednesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    //programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Thursday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                   // programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Friday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                   // programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Saturday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                   // programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Sunday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                   // programLogWeek.ProgramLogDays.Add(programLogDay);
                }
            }
            return programLogWeek;
        }

        public static ProgramLogDayDTO GenerateProgramLogDay(DayOfWeek day, TemplateDayDTO templateDay, DateTime startDate, IEnumerable<LiftingStat> liftingStats)
        {
            var daysUntilSpecificDay = ((int)day - (int)startDate.DayOfWeek + 7) % 7;
            var nextDate = startDate.AddDays(daysUntilSpecificDay);
            var programLogDay = new ProgramLogDayDTO()
            {
                Date = nextDate,
                ProgramLogExercises = CreateProgramLogExercises(templateDay, liftingStats)
            };
            return programLogDay;
        }

        public static IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercises(TemplateDayDTO templateDay, IEnumerable<LiftingStat> liftingStats)
        {
            var programLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = new ProgramLogExerciseDTO()
                {
                    NoOfSets = temExercise.NoOfSets,
                    ExerciseId = temExercise.ExerciseId,
                    ProgramLogRepSchemes = new List<ProgramLogRepSchemeDTO>()
                };
                var user1RMOnLift = liftingStats.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);

                foreach (var temReps in temExercise.TemplateRepSchemes)
                {
                    var programRepSchema = GenerateProgramLogRepScheme("PERCENTAGE", user1RMOnLift.Weight, temReps);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                }
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        public static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string weightProgressionType, decimal? user1RM, TemplateRepSchemeDTO templateRepScheme)
        {
            var weightToLift = 0.00M;

            if (Enum.TryParse(weightProgressionType, out WeightProgressionTypeEnum weightProgressionTypeEnum))
            {
                switch (weightProgressionTypeEnum)
                {
                    case WeightProgressionTypeEnum.PERCENTAGE:
                        var percent = templateRepScheme.Percentage / 100;
                        weightToLift = Math.Round((decimal)((user1RM * percent) * 2), MidpointRounding.AwayFromZero) / 2;
                        break;
                    case WeightProgressionTypeEnum.INCREMENTAL:
                        break;
                }
            }

            return new ProgramLogRepSchemeDTO()
            {
                SetNo = templateRepScheme.SetNo,
                NoOfReps = templateRepScheme.NoOfReps,
                Percentage = templateRepScheme.Percentage,
                WeightLifted = weightToLift,
                AMRAP = templateRepScheme.AMRAP,
            };
        }
    }
}
