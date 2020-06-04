using System;
namespace PowerLifting.ProgramLogs.Service.Exceptions
{
    public class ProgramLogExerciseNotFoundException : Exception
    {
        public ProgramLogExerciseNotFoundException() : base("ProgramLogExercise not found!")
        {
        }
    }
}
