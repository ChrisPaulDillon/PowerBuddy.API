﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.App.Services.Workouts.Util;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IEntityFactory _entityFactory;

        public WorkoutService(PowerLiftingContext context, IMapper mapper, IEntityFactory entityFactory)
        {
            _context = context;
            _mapper = mapper;
            _entityFactory = entityFactory;
        }

        public async Task<string> DoesWorkoutLogExistOnDates(DateTime startDate, DateTime endDate, string userId)
        {
            var startDateOverlap = await _context.WorkoutLog
                .AsNoTracking()
                .Where(x =>
                    x.WorkoutDays.OrderBy(x => x.Date).FirstOrDefault().Date <= startDate.Date &&
                    startDate.Date <= x.WorkoutDays.OrderByDescending(x => x.Date).FirstOrDefault().Date &&
                    x.UserId == userId)
                .Select(x => x.CustomName)
                .FirstOrDefaultAsync();

            if (startDateOverlap != null)
            {
                return startDateOverlap;
            }

            var endDateOverlap = await _context.WorkoutLog
                .AsNoTracking()
                .Where(x =>
                    x.WorkoutDays.OrderBy(x => x.Date).FirstOrDefault().Date <= endDate.Date &&
                    endDate.Date <= x.WorkoutDays.OrderByDescending(x => x.Date).FirstOrDefault().Date &&
                    userId == x.UserId)
                .Select(x => x.CustomName)
                .FirstOrDefaultAsync();

            if (endDateOverlap != null)
            {
                return endDateOverlap;
            }

            return string.Empty;
        }

        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgramExtendedDto tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDto> weightInputs, string weightProgressionType, string userId)
        {
            var listOfDays = new List<WorkoutDay>();

            var currentDate = startDate;
            var dateOfWorkout = DateTime.UtcNow;

      
            foreach (var templateWeek in tp.TemplateWeeks)
            {
                var counter = 1;
                foreach (var templateDay in templateWeek.TemplateDays)
                {
                    var workoutDayOfWeek = workoutOrder[counter];
                    
                    if (DayOfWeek.Monday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Monday);
                    else if (DayOfWeek.Tuesday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Tuesday);
                    else if (DayOfWeek.Wednesday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Wednesday);
                    else if (DayOfWeek.Thursday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Thursday);
                    else if (DayOfWeek.Friday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Friday);
                    else if (DayOfWeek.Saturday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Saturday);
                    else if (DayOfWeek.Sunday.ToString() == workoutDayOfWeek) dateOfWorkout = currentDate.ClosestDateByDay(DayOfWeek.Sunday);

                    var workoutDay = _entityFactory.CreateWorkoutDay(templateWeek.WeekNo, dateOfWorkout, userId);
                    workoutDay.WorkoutExercises = CreateWorkoutExercisesForTemplateDay(templateDay.TemplateExercises, weightInputs, weightProgressionType, userId);
                    listOfDays.Add(workoutDay);
                    counter++;
                }
                currentDate = currentDate.AddDays(7);
            }

            return listOfDays;
        }

        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(IEnumerable<TemplateExerciseDto> templateExercises, IEnumerable<TemplateWeightInputDto> weightInputs, string weightProgressionType, string userId)
        {
            var workoutExercises = new List<WorkoutExercise>();

            foreach (var temExercise in templateExercises)
            {
                var weightInputForExercise = weightInputs.FirstOrDefault(x => x.ExerciseId == temExercise.ExerciseId);

                var workoutSets = CreateWorkoutSetsForTemplateExercise(temExercise, weightInputForExercise, weightProgressionType, out var exerciseTonnage);

                var workoutExercise = new WorkoutExercise()
                {
                    ExerciseId = temExercise.ExerciseId,
                    WorkoutSets = workoutSets.ToList()
                };

                var workoutExerciseTonnage = _entityFactory.CreateWorkoutExerciseTonnage(exerciseTonnage, workoutExercise.ExerciseId, userId);
                workoutExerciseTonnage.WorkoutExercise = workoutExercise;
                _context.WorkoutExerciseTonnage.Add(workoutExerciseTonnage);
                workoutExercises.Add(workoutExercise);
            }
            return workoutExercises;
        }

        public IEnumerable<WorkoutSet> CreateWorkoutSetsForTemplateExercise(TemplateExerciseDto templateExercise, TemplateWeightInputDto weightInputForExercise, string weightProgressionType, out decimal exerciseTonnage)
        {
            var workoutSets = new List<WorkoutSet>();
            exerciseTonnage = 0.00M;

            foreach (var templateSet in templateExercise.TemplateRepSchemes)
            {
                var weight = WorkoutHelper.CalculateWeight(weightProgressionType, weightInputForExercise?.Weight ?? 0, templateSet.Percentage ?? 2.5M);
                var workoutSet = new WorkoutSet()
                {
                    NoOfReps = templateSet.NoOfReps,
                    WeightLifted = weight,
                    AMRAP = templateSet.AMRAP
                };
                exerciseTonnage += WorkoutHelper.CalculateTonnage(workoutSet.WeightLifted, workoutSet.NoOfReps);
                workoutSets.Add(workoutSet);
            }

            return workoutSets;
        }

        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDto createWorkoutExercise, string userId)
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
                exerciseTonnage += WorkoutHelper.CalculateTonnage(createWorkoutExercise.Weight, createWorkoutExercise.Reps);
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
                exerciseTonnage += WorkoutHelper.CalculateTonnage(repScheme.WeightLifted, repScheme.RepsCompleted ?? repScheme.NoOfReps);
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

        public IEnumerable<WorkoutSetDto> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDto> workoutSets)
        {
            return workoutSets
                .GroupBy(x => x.RepsCompleted)
                .Select(g => g.OrderByDescending(x => x.WeightLifted).First())
                .ToList();
        }

        public async Task<WorkoutDayDto> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId)
        {
            var minDate = workoutDate.ClosestDateByDay(DayOfWeek.Monday);
            var maxDate = workoutDate.ClosestDateByDay(DayOfWeek.Sunday);

            //Gets the workout log details (if they exist) on the given week so they can be used to create a workout day on the same week
            return await _context.WorkoutDay
                .AsNoTracking()
                .Where(x => x.Date >= minDate && x.Date <= maxDate && x.UserId == userId && x.WorkoutLogId != null)
                .ProjectTo<WorkoutDayDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<long> GetTotalWorkoutSetsCount()
        {
            return await _context.WorkoutSet.AsNoTracking().LongCountAsync();
        }

        public async Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId)
        {
            return await _context.WorkoutExerciseTonnage
                .AsNoTracking()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .SumAsync(x => x.ExerciseTonnage);
        }
    }
}
