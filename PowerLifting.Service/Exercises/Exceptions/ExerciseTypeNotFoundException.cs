using System;
namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseTypeNotFoundException : Exception
    {
        public ExerciseTypeNotFoundException(string message) : base(message)
        {
        }
    }
}
