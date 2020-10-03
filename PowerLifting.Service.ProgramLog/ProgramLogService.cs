using AutoMapper;
using PowerLifting.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities.LiftingStats;
using PowerLifting.Data.Entities.Templates;

namespace PowerLifting.Service.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramDTO tp, DateTime startDate, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var currentDate = startDate;

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeek = new ProgramLogWeekDTO()
                {
                    StartDate = currentDate,
                    EndDate = currentDate.AddDays(7),
                    WeekNo = templateWeek.WeekNo,
                    UserId = userId,
                    ProgramLogDays = new List<ProgramLogDayDTO>()
                };
                currentDate = currentDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            return listOfProgramWeeks;
        }

        public ICollection<ProgramLogDayDTO> CreateProgramLogDaysForWeekFromTemplate(ProgramLogWeekDTO programLogWeek, Dictionary<int, string> dayOrder, TemplateWeekDTO templateWeek, string userId)
        {
            //if (programLogWeeks.Count() != template.NoOfWeeks) throw new ValidationException(); //program log weeks must equal the template weeks

            var programLogDays = new List<ProgramLogDayDTO>();

            var startDate = programLogWeek.StartDate;

            foreach (var templateDay in templateWeek.TemplateDays)
            {
                var dayOfWeek = dayOrder[templateDay.DayNo]; //Get the correct day order the user selected
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Monday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Tuesday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Wednesday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Thursday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Friday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Saturday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var daysUntilSpecificDay = ((int) DayOfWeek.Sunday - (int) startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = new ProgramLogDayDTO()
                    {
                        Date = nextDate,
                        ProgramLogExercises = new List<ProgramLogExerciseDTO>(),
                        UserId = programLogWeek.UserId
                    };
                    programLogDays.Add(programLogDay);
                }
            }

            return programLogDays;
        }

        public IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForDay(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats)
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
