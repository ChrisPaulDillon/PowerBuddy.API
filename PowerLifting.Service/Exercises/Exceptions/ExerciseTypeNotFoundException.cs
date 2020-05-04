using System;

namespace PowerLifting.Service.Exercises.Exceptions
{
    public class ExerciseTypeNotFoundException : Exception
    {
        public ExerciseTypeNotFoundException() : base("The ExerciseType associated with the given Id cannot be found")
        {
        }
    }
}