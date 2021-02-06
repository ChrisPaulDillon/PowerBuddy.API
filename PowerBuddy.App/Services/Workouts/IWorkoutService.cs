using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.App.Services.Workouts.Models;
using PowerBuddy.App.Services.Workouts.Strategies;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.Workouts
{
    public interface IWorkoutService
    {
        public Task<bool> DoesWorkoutLogExistOnDates(DateTime startDate, string userId);
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDto> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDto> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDto createWorkoutExercise, string userId);
        public Task CreateWorkoutExerciseAudit(int exerciseId, string userId);
        public Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId);
        IEnumerable<WorkoutSetDto> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDto> workoutSets);
        public Task<WorkoutDayDto> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId);
        public Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);
        public Task<long> GetTotalWorkoutSetsCount();

    }
}
