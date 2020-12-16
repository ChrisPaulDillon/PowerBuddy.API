using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.Workouts.Models;

namespace PowerBuddy.Services.Workouts
{
    public interface IWorkoutService
    {
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);

        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDTO createWorkoutExercise, string userId);
        public Task CreateWorkoutExerciseAudit(int exerciseId, string userId);
        public Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId);
    }
}
