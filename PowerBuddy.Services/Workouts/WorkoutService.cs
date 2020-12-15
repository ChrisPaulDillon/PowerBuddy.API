﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.ProgramLogs.Util;
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
                var counter = 0;
                foreach (var templateDay in templateWeek.TemplateDays)
                {
                    var workoutDayOfWeek = workoutOrder[counter];
                    DateTime date = DateTime.UtcNow;

                    if (DayOfWeek.Monday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Monday);
                    if (DayOfWeek.Tuesday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Tuesday);
                    if (DayOfWeek.Wednesday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Wednesday);
                    if (DayOfWeek.Thursday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Thursday);
                    if (DayOfWeek.Friday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Friday);
                    if (DayOfWeek.Saturday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Saturday);
                    if (DayOfWeek.Sunday.ToString() == workoutDayOfWeek) date = currentDate.StartOfWeek(DayOfWeek.Sunday);

                    var workoutDay = _entityFactory.CreateWorkoutDay(templateWeek.WeekNo, date, userId);
                    workoutDay.WorkoutExercises = CreateWorkoutExercisesForTemplateDay(templateDay, weightInputs, calculateRepWeight, userId);
                    currentDate = currentDate.AddDays(7);
                    listOfDays.Add(workoutDay);
                    counter++;
                }
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

                //workoutExercise.wor = _entityFactory.CreateProgramLogExerciseTonnage(programLogExercise.ProgramLogExerciseId, exerciseTonnage, userId, programLogExercise.ExerciseId);
                //workoutExercise.ProgramLogExerciseTonnageId = programLogExercise.ProgramLogExerciseTonnage.ProgramLogExerciseTonnageId;
                workoutExercises.Add(workoutExercise);
            }
            return workoutExercises;
        }
    }
}