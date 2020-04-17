using System;

namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException(string message) : base(message)
        {
        }
    }
}