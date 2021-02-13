using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Extensions.Validators
{
    public class WorkoutExerciseCollectionValidator : PropertyValidator
    {
        protected override string GetDefaultMessageTemplate()
        {
            return "{PropertyValue} must have at least one set for each exercise";
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var workoutExercises = (IEnumerable<WorkoutExerciseDto>) context.PropertyValue;

            if (workoutExercises == null)
            {
                return false;
            }

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