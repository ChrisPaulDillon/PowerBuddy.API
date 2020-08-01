﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.ProgramLogs.Service.Util
{
    public static class ProgramLogHelper
    {
        public static DaySelected CalculateDayOrder(DaySelected ds)
        {
            var programDayOrder = new Dictionary<int, string>();

            var startingDay = ds.StartDate.DayOfWeek;
            var startingNo = (int)ds.StartDate.DayOfWeek;

            var counter = 1;
            programDayOrder.Add(counter, startingDay.ToString());

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>().ToList().Skip(startingNo + 1))
            {
                switch (day)
                {
                    case DayOfWeek.Monday:
                    {
                        if (ds.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (ds.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (ds.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (ds.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (ds.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (ds.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (ds.Sunday) programDayOrder.Add(++counter, day.ToString());
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
                        if (ds.Monday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Tuesday:
                    {
                        if (ds.Tuesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Wednesday:
                    {
                        if (ds.Wednesday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Thursday:
                    {
                        if (ds.Thursday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Friday:
                    {
                        if (ds.Friday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Saturday:
                    {
                        if (ds.Saturday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                    case DayOfWeek.Sunday:
                    {
                        if (ds.Sunday) programDayOrder.Add(++counter, day.ToString());
                        break;
                    }
                }
            }

            ds.ProgramOrder = programDayOrder;
            return ds;
        }
        public static IEnumerable<ProgramLogWeekDTO> GenerateProgramWeekDates(DaySelected ds, TemplateProgramDTO tp, string userId, IEnumerable<LiftingStatDTO> liftingStats)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeekWithDays = CreateProgramLogWeek(templateWeek, ds, userId, liftingStats);
                listOfProgramWeeks.Add(programLogWeekWithDays);
                ds.StartDate = ds.StartDate.AddDays(7);
            }

            return listOfProgramWeeks;
        }

        public static ProgramLogWeekDTO CreateProgramLogWeek(TemplateWeekDTO templateWeek, DaySelected ds, string userId, IEnumerable<LiftingStatDTO> liftingStats)
        {
            var programLogWeek = new ProgramLogWeekDTO()
            {
                StartDate = ds.StartDate,
                EndDate = ds.StartDate.AddDays(7),
                WeekNo = templateWeek.WeekNo,
                UserId = userId,
                ProgramLogDays = new List<ProgramLogDayDTO>()
            };

            var startDate = programLogWeek.StartDate;
            foreach (var templateDay in templateWeek.TemplateDays)
            {
                var dayOfWeek = ds.ProgramOrder[templateDay.DayNo];
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Monday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Tuesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Wednesday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Thursday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Friday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Saturday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var programLogDay = GenerateProgramLogDay(DayOfWeek.Sunday, templateDay, startDate, liftingStats);
                    programLogDay.UserId = programLogWeek.UserId;
                    programLogWeek.ProgramLogDays.Add(programLogDay);
                }
            }
            return programLogWeek;
        }

        public static ProgramLogDayDTO GenerateProgramLogDay(DayOfWeek day, TemplateDayDTO templateDay, DateTime startDate, IEnumerable<LiftingStatDTO> liftingStats)
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

        public static IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercises(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats)
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
                    var programRepSchema = GenerateProgramLogRepScheme("PERCENTAGE", (double)(user1RMOnLift.Weight), temReps);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                }
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        public static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(string weightProgressionType, double user1RM, TemplateRepSchemeDTO templateRepScheme)
        {
            var weightToLift = 0.00M;

            if (Enum.TryParse(weightProgressionType, out WeightProgressionTypeEnum weightProgressionTypeEnum))
            {
                switch (weightProgressionTypeEnum)
                {
                    case WeightProgressionTypeEnum.PERCENTAGE:
                        var percent = templateRepScheme.Percentage / 100;
                        weightToLift = Convert.ToDecimal(user1RM * percent);
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
