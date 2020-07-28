using System;

namespace PowerLifting.Data.Exceptions.Exercises
{
    public class ExerciseAlreadyExistsException : Exception
    {
        public ExerciseAlreadyExistsException() : base("Exercise with the supplied parameters already exists")
        {
        }
    }
}
