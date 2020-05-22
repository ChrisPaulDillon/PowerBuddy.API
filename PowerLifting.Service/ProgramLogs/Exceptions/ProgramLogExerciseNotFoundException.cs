using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogExerciseNotFoundException : Exception
    {
        public ProgramLogExerciseNotFoundException() : base("ProgramLogExercise not found!")
        {
        }
    }
}
