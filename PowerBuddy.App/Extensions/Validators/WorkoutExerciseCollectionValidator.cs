using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Extensions.Validators
{
    public class WorkoutExerciseCollectionValidator : PropertyValidator
    {
        public WorkoutExerciseCollectionValidator() : base("{PropertyValue} must have at least one set for each exercise")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var workoutExercises = (IEnumerable<WorkoutExerciseDto>) context.PropertyValue;
            foreach (var workoutExercise in workoutExercises)
            {
                if (workoutExercise.WorkoutSets == null || !workoutExercise.WorkoutSets.Any())
                {
                    return false;
                }
            }

            return true;
        }
    }
}