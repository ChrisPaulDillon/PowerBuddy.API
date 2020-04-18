using System;
namespace PowerLifting.Service.ProgramLogs.Exceptions
{
    public class ProgramLogExerciseNotFoundException : Exception
    {
        public ProgramLogExerciseNotFoundException() : base("ProgramLogExercise with the associated ID was not found!")
        {
        }
    }
}
