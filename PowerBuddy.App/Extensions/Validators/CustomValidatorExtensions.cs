using System.Collections.Generic;
using FluentValidation;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.DTOs.WorkoutTemplates;

namespace PowerBuddy.App.Extensions.Validators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IEnumerable<WorkoutExerciseDto>> ValidWorkoutExerciseCollection<T>(
            this IRuleBuilder<T, IEnumerable<WorkoutExerciseDto>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new WorkoutExerciseCollectionValidator());
        }

        public static IRuleBuilderOptions<T, IEnumerable<WorkoutTemplateExerciseDto>> ValidWorkoutTemplateExerciseCollection<T>(
            this IRuleBuilder<T, IEnumerable<WorkoutTemplateExerciseDto>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new WorkoutTemplateExerciseCollectionValidator());
        }
    }
}
