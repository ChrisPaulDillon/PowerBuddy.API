using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.ProgramLogs.Util;
using PowerBuddy.Services.Workouts.Models;
using PowerBuddy.Services.Workouts.Util;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;
        private readonly IEntityFactory _entityFactory;

        public WorkoutService(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
            _entityFactory = entityFactory;
        }

        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, 
            DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDTO> weightInputs, 
            ICalculateRepWeight calculateRepWeight, string userId)
        {
            var listOfDays = new List<WorkoutDay>();

            var currentDate = startDate;

            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var counter = 1;
                foreach (var templateDay in templateWeek.TemplateDays)
                {
                    var workoutDayOfWeek = workoutOrder[counter];
                    var date = DateTime.UtcNow;

                    if (DayOfWeek.Monday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Monday);
                    else if (DayOfWeek.Tuesday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Tuesday);
                    else if (DayOfWeek.Wednesday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Wednesday);
                    else if (DayOfWeek.Thursday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Thursday);
                    else if (DayOfWeek.Friday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Friday);
                    else if (DayOfWeek.Saturday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Saturday);
                    else if (DayOfWeek.Sunday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Sunday);

                    var workoutDay = _entityFactory.CreateWorkoutDay(templateWeek.WeekNo, date, userId);
                    workoutDay.WorkoutExercises = CreateWorkoutExercisesForTemplateDay(templateDay, weightInputs, calculateRepWeight, userId);
                    listOfDays.Add(workoutDay);
                    counter++;
                }
                currentDate = currentDate.AddDays(7);
            }

            return listOfDays;
        }

        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId)
        {
            var workoutExercises = new List<WorkoutExercise>();

            foreach (var temExercise in templateDay.TemplateExercises)
            {
                var workoutExercise = _entityFactory.CreateWorkoutExercise(temExercise.ExerciseId);
                var weightInputForExercise = weightInputs.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);
                var exerciseTonnage = 0.00M;

                foreach (var templateSet in temExercise.TemplateRepSchemes)
                {
                    var weight = calculateRepWeight.CalculateWeight(weightInputForExercise?.Weight ?? 0, templateSet.Percentage ?? 2.5M);
                    var workoutSet = _entityFactory.CreateWorkoutSet(templateSet.NoOfReps, weight, templateSet.AMRAP);
                    exerciseTonnage += WorkoutHelper.CalculateTonnage(workoutSet.WeightLifted, workoutSet.NoOfReps);
                    workoutExercise.WorkoutSets.Add(workoutSet);
                }

                workoutExercise.WorkoutExerciseTonnage = _entityFactory.CreateWorkoutExerciseTonnage(exerciseTonnage, workoutExercise.ExerciseId, userId);
                workoutExercises.Add(workoutExercise);
            }
            return workoutExercises;
        }

        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDTO createWorkoutExercise, string userId)
        {
            var setCollection = new List<WorkoutSet>();

            var exerciseTonnage = 0.00M;

            var workoutExercise = new WorkoutExercise()
            {
                ExerciseId = createWorkoutExercise.ExerciseId,
                WorkoutDayId = createWorkoutExercise.WorkoutDayId,
            };

            for (var i = 1; i < createWorkoutExercise.Sets + 1; i++)
            {
                exerciseTonnage += ProgramLogHelper.CalculateTonnage(createWorkoutExercise.Weight, createWorkoutExercise.Reps);
                var set = _entityFactory.CreateWorkoutSet(createWorkoutExercise.Reps, createWorkoutExercise.Weight, false);
                setCollection.Add(set);
                
            }

            workoutExercise.WorkoutSets = setCollection;
            workoutExercise.WorkoutExerciseTonnage = _entityFactory.CreateWorkoutExerciseTonnage(exerciseTonnage, workoutExercise.ExerciseId, userId);

            return workoutExercise;
        }

        public async Task CreateWorkoutExerciseAudit(int exerciseId, string userId)
        {
            var exerciseAudit = await _context.WorkoutExerciseAudit
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .FirstOrDefaultAsync();

            if (exerciseAudit == null)
            {
                exerciseAudit = new WorkoutExerciseAudit()
                {
                    ExerciseId = exerciseId, 
                    UserId = userId,
                    SelectedCount = 1
                };
                _context.WorkoutExerciseAudit.Add(exerciseAudit);
            }
            else
            {
                exerciseAudit.SelectedCount++;
            }
        }

        public async Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId)
        {
            var workoutExerciseTonnage = await _context.WorkoutExerciseTonnage
                .FirstOrDefaultAsync(x => x.WorkoutExerciseId == workoutExercise.WorkoutExerciseId);

            var exerciseTonnage = 0.00M;

            foreach (var repScheme in workoutExercise.WorkoutSets)
            {
                exerciseTonnage += WorkoutHelper.CalculateTonnage((decimal)repScheme.WeightLifted, repScheme.RepsCompleted ?? repScheme.NoOfReps);
            }

            if (workoutExerciseTonnage == null)
            {
                workoutExerciseTonnage = _entityFactory.CreateWorkoutExerciseTonnage(exerciseTonnage, workoutExercise.ExerciseId, userId);
                _context.WorkoutExerciseTonnage.Add(workoutExerciseTonnage);
            }
            else
            {
                workoutExerciseTonnage.ExerciseTonnage = exerciseTonnage;
            }

            return workoutExerciseTonnage;
        }

        public IEnumerable<WorkoutSetDTO> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDTO> workoutSets)
        {
            return workoutSets
                .GroupBy(x => x.RepsCompleted)
                .Select(g => g.OrderByDescending(x => x.WeightLifted).First())
                .ToList();
        }

        public async Task<WorkoutDayDTO> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId)
        {
            var minDate = workoutDate.StartOfWeek(DayOfWeek.Monday);
            var maxDate = workoutDate.EndOfWeek(DayOfWeek.Sunday);

            //Gets the workout log details (if they exist) on the given week so they can be used to create a workout day on the same week
            return await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.Date >= minDate && x.Date <= maxDate && x.UserId == userId && x.WorkoutLogId != null)
                .ProjectTo<WorkoutDayDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
