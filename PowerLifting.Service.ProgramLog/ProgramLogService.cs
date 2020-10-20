using AutoMapper;
using PowerLifting.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Factories;
using PowerLifting.Service.ProgramLogs.Factories;
using PowerLifting.Service.ProgramLogs.Strategies;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.Service.ProgramLogs
{
    public class ProgramLogService : IProgramLogService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;

        public ProgramLogService(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task IsProgramLogAlreadyActive(string userId)
        {
            var doesExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.Active && x.UserId == userId);
            if (doesExist) throw new ProgramLogAlreadyActiveException();
        }

        public IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramDTO tp, DateTime startDate, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeekDTO>();

            var currentDate = startDate;

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeek = ProgramLogFactory.CreateProgramLogWeek(currentDate, templateWeek.WeekNo, userId);
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
                    var programLogDay = ProgramLogFactory.CreateProgramLogDay(nextDate, userId);
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

        public IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<LiftingStatDTO> liftingStats, ICalculateRepWeight calculateRepWeight)
        {
            var programLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = ProgramLogFactory.CreateProgramLogExercise(temExercise.NoOfSets, temExercise.ExerciseId);
                var user1RMOnLift = liftingStats.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);

                foreach (var temRepSet in temExercise.TemplateRepSchemes)
                {
                    var weight = calculateRepWeight.CalculateWeight(user1RMOnLift.Weight ?? 0, temRepSet.Percentage?? 0);
                    var programRepSchema = GenerateProgramLogRepScheme(weight, temRepSet);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepSchema);
                }
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        public static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(decimal weight, TemplateRepSchemeDTO templateRepScheme)
        {
            return ProgramLogFactory.CreateProgramLogRepScheme(templateRepScheme.SetNo, templateRepScheme.NoOfReps, templateRepScheme.Percentage?? 0, weight, templateRepScheme.AMRAP);
        }

        public CProgramLogExerciseDTO CreateRepSchemesForExercise(CProgramLogExerciseDTO programLogExercise)
        {
            var repSchemeCollection = new List<ProgramLogRepSchemeDTO>();

            for (var i = 1; i < programLogExercise.NoOfSets + 1; i++)
            {
                if (programLogExercise.Reps != null && programLogExercise.Weight != null)
                {
                    var repScheme = _dtoFactory.CreateRepScheme(i, (int)programLogExercise.Reps, (decimal)programLogExercise.Weight);
                    repSchemeCollection.Add(repScheme);
                }
            }

            programLogExercise.ProgramLogRepSchemes = repSchemeCollection;
            return programLogExercise;
        }

    }
}
