using System;
namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseValidationException : Exception
    {
        public ExerciseValidationException(string message) : base(message)
        {
        }
    }
}
