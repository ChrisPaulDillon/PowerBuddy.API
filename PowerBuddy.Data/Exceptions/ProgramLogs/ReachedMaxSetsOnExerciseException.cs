using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ReachedMaxSetsOnExerciseException : Exception
    {
        public ReachedMaxSetsOnExerciseException() : base("Max sets has been reached for this exercise") { }
    }
}
