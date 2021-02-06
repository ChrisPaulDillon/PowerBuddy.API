using System.Collections.Generic;
using FluentValidation;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Extensions.Validators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IEnumerable<WorkoutExerciseDto>> ValidWorkoutExerciseCollection<T>(
            this IRuleBuilder<T, IEnumerable<WorkoutExerciseDto>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new WorkoutExerciseCollectionValidator());
        }
    }
}
