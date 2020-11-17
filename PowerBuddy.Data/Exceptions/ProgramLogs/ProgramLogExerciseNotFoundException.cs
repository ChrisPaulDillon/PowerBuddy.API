using System;

namespace PowerBuddy.Data.Exceptions.ProgramLogs
{
    public class ProgramLogExerciseNotFoundException : Exception
    {
        public ProgramLogExerciseNotFoundException() : base("ProgramLogExercise not found!")
        {
        }
    }
}
