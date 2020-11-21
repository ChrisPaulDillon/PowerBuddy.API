using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Exceptions.TemplatePrograms;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.ProgramLogs.Util;

namespace PowerBuddy.Services.ProgramLogs
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
                                                                                   && x.StartDate.Date < endDate
                                                                                   && x.StartDate.Date > startDate);
            if (doesExist) throw new ProgramLogAlreadyActiveException();
        }

        public bool IsDateOnWorkoutDay(DateTime date, Dictionary<int, string> dayOrder, int counter)
        {
            var dayOfWeek = date.DayOfWeek.ToString();
            var dayOfWorkout = dayOrder[counter + 1]; //Get the correct day order the user selected

            if (dayOfWeek == dayOfWorkout) return true;

            return false;
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

        public IEnumerable<ProgramLogWeek> CreateProgramLogWeeksFromTemplate(TemplateProgramExtendedDTO tp, DateTime startDate, int iteration, string userId)
        {
            var listOfProgramWeeks = new List<ProgramLogWeek>();

            var currentDate = startDate;

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var programLogWeek = _entityFactory.CreateProgramLogWeekWithDays(currentDate, templateWeek.WeekNo + (iteration * tp.NoOfWeeks), userId);
                currentDate = currentDate.AddDays(7);
                listOfProgramWeeks.Add(programLogWeek);
            }

            return listOfProgramWeeks;
        }

        public IEnumerable<ProgramLogExercise> CreateProgramLogExercisesForTemplateDay(TemplateDayDTO templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId)
        {
            var programLogExercises = new List<ProgramLogExercise>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var programLogExercise = _entityFactory.CreateProgramLogExercise(temExercise.NoOfSets, temExercise.ExerciseId);
                var user1RMOnLift = weightInputs.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);
                var exerciseTonnage = 0.00M;

                foreach (var temRepSet in temExercise.TemplateRepSchemes)
                {
                    var weight = calculateRepWeight.CalculateWeight(user1RMOnLift.Weight ?? 0, temRepSet.Percentage ?? 2.5M);
                    var programRepScheme = GenerateProgramLogRepScheme(weight, temRepSet);
                    exerciseTonnage += ProgramLogHelper.CalculateTonnage(programRepScheme.WeightLifted, programRepScheme.NoOfReps);
                    programLogExercise.ProgramLogRepSchemes.Add(programRepScheme);
                }

                programLogExercise.ProgramLogExerciseTonnage = _entityFactory.CreateProgramLogExerciseTonnage(programLogExercise.ProgramLogExerciseId, exerciseTonnage, userId, programLogExercise.ExerciseId);
                programLogExercise.ProgramLogExerciseTonnageId = programLogExercise.ProgramLogExerciseTonnage.ProgramLogExerciseTonnageId;
                programLogExercises.Add(programLogExercise);
            }
            return programLogExercises;
        }

        public ProgramLogRepScheme GenerateProgramLogRepScheme(decimal weight, TemplateRepSchemeDTO templateRepScheme)
        {
            return _entityFactory.CreateProgramLogRepScheme(templateRepScheme.SetNo, templateRepScheme.NoOfReps, templateRepScheme.Percentage ?? 0, weight, templateRepScheme.AMRAP);
        }

        public ProgramLogExerciseDTO CreateRepSchemesForExercise(ProgramLogExerciseDTO programLogExercise, string userId)
        {
            var repSchemeCollection = new List<ProgramLogRepSchemeDTO>();

            var exerciseTonnage = 0.00M;

            for (var i = 1; i < programLogExercise.NoOfSets + 1; i++)
            {
                if (programLogExercise.Reps != null && programLogExercise.Weight != null)
                {
                    exerciseTonnage += ProgramLogHelper.CalculateTonnage((decimal)programLogExercise.Weight, (int)programLogExercise.Reps);
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

        public async Task<TemplateProgramExtendedDTO> GetTemplateProgramById(int templateProgramId)
        {
            var templateProgram = await _context.TemplateProgram
                .AsNoTracking()
                .Where(x => x.TemplateProgramId == templateProgramId)
                .ProjectTo<TemplateProgramExtendedDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if (templateProgram == null) throw new TemplateProgramNotFoundException();

            return templateProgram;
        }

        public async Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId)
        {
            return await _context.ProgramLogExerciseTonnage.AsNoTracking().Where(x => x.UserId == userId && x.ExerciseId == exerciseId).SumAsync(x => x.ExerciseTonnage);
        }
    }
}
