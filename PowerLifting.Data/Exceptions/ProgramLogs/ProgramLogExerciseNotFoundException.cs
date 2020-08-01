using System;

namespace PowerLifting.Data.Exceptions.ProgramLogs
{
    public class ProgramLogExerciseNotFoundException : Exception
    {
        public ProgramLogExerciseNotFoundException() : base("ProgramLogExercise not found!")
        {
        }
    }
}
