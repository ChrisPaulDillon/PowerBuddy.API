using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.App.Services.Workouts.Models;
using PowerBuddy.App.Services.Workouts.Strategies;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.Workouts
{
    public interface IWorkoutService
    {
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDTO createWorkoutExercise, string userId);
        public Task CreateWorkoutExerciseAudit(int exerciseId, string userId);
        public Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId);
        IEnumerable<WorkoutSetDTO> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDTO> workoutSets);
        public Task<WorkoutDayDTO> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId);
        public Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);
        public Task<long> GetTotalWorkoutSetsCount();

    }
}
