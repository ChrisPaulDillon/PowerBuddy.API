using System.Collections.Generic;
using FluentValidation;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.App.Extensions.Validators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, IEnumerable<WorkoutExerciseDTO>> ValidWorkoutExerciseCollection<T>(
            this IRuleBuilder<T, IEnumerable<WorkoutExerciseDTO>> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new WorkoutExerciseCollectionValidator());
        }
    }
}
