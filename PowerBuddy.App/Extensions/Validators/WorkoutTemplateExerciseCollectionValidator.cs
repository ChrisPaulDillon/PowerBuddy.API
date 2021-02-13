using System.Collections.Generic;
using System.Linq;
using FluentValidation.Validators;
using PowerBuddy.Data.DTOs.WorkoutTemplates;

namespace PowerBuddy.App.Extensions.Validators
{
    public class WorkoutTemplateExerciseCollectionValidator : PropertyValidator
    {
        protected override string GetDefaultMessageTemplate()
        {
            return "{PropertyValue} must have at least one set for each exercise";
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var workoutExercises = (IEnumerable<WorkoutTemplateExerciseDto>)context.PropertyValue;

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