using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ReachedMaxSetsOnExerciseException : Exception
    {
        public ReachedMaxSetsOnExerciseException() : base("Max sets has been reached for this exercise") { }
    }
}
