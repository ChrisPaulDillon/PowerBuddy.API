using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class ReachedMaxSetsOnExerciseException : Exception
    {
        public ReachedMaxSetsOnExerciseException() : base("Max sets has been reached for this exercise") { }
    }
}
