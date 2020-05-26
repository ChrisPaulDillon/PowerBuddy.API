using System;

namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseMuscleGroupNotFoundException : Exception
    {
        public ExerciseMuscleGroupNotFoundException(string message) : base(message)
        {
        }
    }
}