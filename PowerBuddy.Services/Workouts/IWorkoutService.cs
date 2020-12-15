using System;
using System.Collections;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Services.ProgramLogs.Strategies;

namespace PowerBuddy.Services.Workouts
{
    public interface IWorkoutService
    {
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgram tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);

        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(TemplateDay templateDay, IEnumerable<TemplateWeightInputDTO> weightInputs, ICalculateRepWeight calculateRepWeight, string userId);
    }
}
