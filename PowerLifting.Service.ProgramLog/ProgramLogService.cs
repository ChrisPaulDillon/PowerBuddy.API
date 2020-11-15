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
        private readonly IEntityFactory _entityFactory;

        public ProgramLogService(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
            _entityFactory = entityFactory;
        }

        public async Task IsProgramLogAlreadyActive(DateTime startDate, DateTime endDate, string userId)
        {
            var doesExist = await _context.ProgramLog.AsNoTracking().AnyAsync(x => x.UserId == userId 
                                                                                   && x.IsDeleted == false 
                                                                                   && x.StartDate.Date < endDate
                                                                                   && x.StartDate.Date > startDate);
            if (doesExist) throw new ProgramLogAlreadyActiveException();
        }

        public async Task<ProgramLogExerciseTonnage> UpdateExerciseTonnage(ProgramLogExercise programLogExercise, string userId)
        {
            var programLogExerciseTonnage = await _context.ProgramLogExerciseTonnage.FirstOrDefaultAsync(x =>
                x.ProgramLogExerciseId == programLogExercise.ProgramLogExerciseId);

            var exerciseTonnage = 0.00M;

            foreach (var repScheme in programLogExercise.ProgramLogRepSchemes)
            {
                exerciseTonnage += ProgramLogHelper.CalculateTonnage((decimal)repScheme.WeightLifted, repScheme.RepsCompleted ?? repScheme.NoOfReps);
            }

            if (programLogExerciseTonnage == null)
            {
                programLogExerciseTonnage = _entityFactory.CreateProgramLogExerciseTonnage(programLogExercise.ProgramLogExerciseId, exerciseTonnage, userId, programLogExercise.ExerciseId);
                _context.ProgramLogExerciseTonnage.Add(programLogExerciseTonnage);
            }
            else
            {
                programLogExerciseTonnage.ExerciseTonnage = exerciseTonnage;
            }

            return programLogExerciseTonnage;
        }

        public IEnumerable<ProgramLogWeekDTO> CreateProgramLogWeeksFromTemplate(TemplateProgramExtendedDTO tp, DateTime startDate, string userId)
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
            var programLogDays = new List<ProgramLogDayDTO>();

            var startDate = programLogWeek.StartDate;

            foreach (var templateDay in templateWeek.TemplateDays)
            {
                var dayOfWeek = dayOrder[templateDay.DayNo]; //Get the correct day order the user selected
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Monday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Tuesday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Wednesday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Thursday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Thursday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Friday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Friday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Saturday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Saturday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
                else if (dayOfWeek == DayOfWeek.Sunday.ToString())
                {
                    var daysUntilSpecificDay = ((int)DayOfWeek.Sunday - (int)startDate.DayOfWeek + 7) % 7;
                    var nextDate = startDate.AddDays(daysUntilSpecificDay);
                    var programLogDay = _dtoFactory.CreateProgramLogDayDTO(nextDate, userId);
                    programLogDays.Add(programLogDay);
                }
            }

            return programLogDays;
        }

        public IEnumerable<ProgramLogExerciseDTO> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId)
        {
            var programLogExercises = new List<ProgramLogExerciseDTO>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = ProgramLogFactory.CreateProgramLogExercise(temExercise.NoOfSets, temExercise.ExerciseId);
                var user1RMOnLift = weightInputs.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);
                var exerciseTonnage = 0.00M;

                foreach (var temRepSet in temExercise.TemplateRepSchemes)
                {
                    var weight = calculateRepWeight.CalculateWeight(user1RMOnLift.Weight ?? 0, temRepSet.Percentage ?? 2.5M);
                    var programRepScheme = GenerateProgramLogRepScheme(weight, temRepSet);
                    exerciseTonnage = +ProgramLogHelper.CalculateTonnage(programRepScheme.WeightLifted, programLogExercise.NoOfSets);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepScheme);
                }

                programLogExercise.ProgramLogExerciseTonnageDTO = _dtoFactory.CreateProgramLogExerciseTonnageDTO(programLogExercise.ProgramLogExerciseId, exerciseTonnage, userId, programLogExercise.ExerciseId);
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        public static ProgramLogRepSchemeDTO GenerateProgramLogRepScheme(decimal weight, TemplateRepSchemeDTO templateRepScheme)
        {
            return ProgramLogFactory.CreateProgramLogRepScheme(templateRepScheme.SetNo, templateRepScheme.NoOfReps, templateRepScheme.Percentage ?? 0, weight, templateRepScheme.AMRAP);
        }

        public ProgramLogExerciseDTO CreateRepSchemesForExercise(ProgramLogExerciseDTO programLogExercise, string userId)
        {
            var repSchemeCollection = new List<ProgramLogRepSchemeDTO>();

            var exerciseTonnage = 0.00M;

            for (var i = 1; i < programLogExercise.NoOfSets + 1; i++)
            {
                if (programLogExercise.Reps != null && programLogExercise.Weight != null)
                {
                    exerciseTonnage = +ProgramLogHelper.CalculateTonnage((decimal)programLogExercise.Weight, (int)programLogExercise.Reps);
                    var repScheme = _dtoFactory.CreateProgramLogRepSchemeDTO(i, (int)programLogExercise.Reps, (decimal)programLogExercise.Weight);
                    repSchemeCollection.Add(repScheme);
                }
            }

            programLogExercise.ProgramLogRepSchemes = repSchemeCollection;
            programLogExercise.ProgramLogExerciseTonnageDTO = _dtoFactory.CreateProgramLogExerciseTonnageDTO(programLogExercise.ProgramLogExerciseId, exerciseTonnage, userId, programLogExercise.ExerciseId);

            return programLogExercise;
        }

        public async Task<IEnumerable<DateTime>> GetAllProgramLogDatesForUser(string userId)
        {
            return await _context.ProgramLogDay
                .Where(x => x.UserId == userId)
                .Select(x => x.Date.Date)
                .ToListAsync();
        }

        public async Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId)
        {
            return await _context.ProgramLogExerciseTonnage.AsNoTracking().Where(x => x.UserId == userId && x.ExerciseId == exerciseId).SumAsync(x => x.ExerciseTonnage);
        }
    }
}
