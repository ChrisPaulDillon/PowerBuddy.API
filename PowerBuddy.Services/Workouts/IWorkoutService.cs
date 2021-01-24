﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.Workouts.Models;

namespace PowerBuddy.Services.Workouts
{
    public interface IWorkoutService
    {
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId, bool isMetric);

        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId, bool isMetric);
        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDTO createWorkoutExercise, string userId, bool isMetric);
        public Task CreateWorkoutExerciseAudit(int exerciseId, string userId);
        public Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId);
        IEnumerable<WorkoutSetDTO> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDTO> workoutSets);
        public Task<WorkoutDayDTO> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId);

        public Task<long> GetTotalWorkoutSetsCount();

    }
}
