using System;

namespace PowerBuddy.Data.Exceptions.Exercises
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException() : base("Exercise Not Found")
        {

        }
    }
}