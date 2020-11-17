using System;

namespace PowerBuddy.Data.Exceptions.Exercises
{
    public class ExerciseTypeNotFoundException : Exception
    {
        public ExerciseTypeNotFoundException() : base("ExerciseType Not Found")
        {

        }
    }
}
