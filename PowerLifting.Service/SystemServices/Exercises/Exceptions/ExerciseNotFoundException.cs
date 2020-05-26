using System;

namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException() : base("The Exercise associated with the given Id cannot be found")
        {
        }
    }
}