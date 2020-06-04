using PowerLifting.Entity.System.Exercises.Models;
using PowerLifting.Service.Exercises.Exceptions;

namespace PowerLifting.Service.Exercises.Validators
{
    public class ExerciseValidator
    {

        public ExerciseValidator()
        {
        }

        public void ValidateExerciseId(int exerciseId)
        {
            if (exerciseId < 1)
            {
                throw new ExerciseValidationException("ExerciseId cannot be less than one");
            }
        }

        public void ValidateExerciseExists(Exercise exercise)
        {
            if (exercise == null)
            {
                throw new ExerciseNotFoundException();
            }
        }
    }
}
