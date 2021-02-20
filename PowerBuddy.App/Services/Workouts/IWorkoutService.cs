using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PowerBuddy.Data.Dtos.Templates;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.App.Services.Workouts
{
    public interface IWorkoutService
    {
        public Task<string> DoesWorkoutLogExistOnDates(DateTime startDate, DateTime endDate, string userId);
        public IEnumerable<WorkoutDay> CreateWorkoutDaysFromTemplate(TemplateProgramExtendedDto tp, DateTime startDate, Dictionary<int, string> workoutOrder, IEnumerable<TemplateWeightInputDto> weightInputs, string weightProgressionType, string userId);
        public IEnumerable<WorkoutExercise> CreateWorkoutExercisesForTemplateDay(IEnumerable<TemplateExerciseDto> templateExercises, IEnumerable<TemplateWeightInputDto> weightInputs, string weightProgressionType, string userId);
        public IEnumerable<WorkoutSet> CreateWorkoutSetsForTemplateExercise(TemplateExerciseDto templateExercise, TemplateWeightInputDto weightInputForExercise, string weightProgressionType, out decimal exerciseTonnage);
        public WorkoutExercise CreateSetsForExercise(CreateWorkoutExerciseDto createWorkoutExercise, string userId);
        public Task CreateWorkoutExerciseAudit(int exerciseId, string userId);
        public Task<WorkoutExerciseTonnage> UpdateExerciseTonnage(WorkoutExercise workoutExercise, string userId);
        IEnumerable<WorkoutSetDto> GetHighestWeightRepSchemeForEachRepFromCollection(IEnumerable<WorkoutSetDto> workoutSets);
        public Task<WorkoutDayDto> GetWorkoutLogDetailsForWeek(DateTime workoutDate, string userId);
        public Task<decimal> CalculateLifetimeTonnageForExercise(int exerciseId, string userId);
        public Task<long> GetTotalWorkoutSetsCount();

    }
}
