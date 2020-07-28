using System;

namespace PowerLifting.Data.Exceptions.Exercises
{
    public class ExerciseMuscleGroupNotFoundException : Exception
    {
        public ExerciseMuscleGroupNotFoundException() : base("ExerciseMuscleGroup Not Found")
        {

        }
    }
}