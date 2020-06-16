using System;
namespace PowerLifting.Systems.Service.Exceptions
{
    public class ExerciseAlreadyExistsException : Exception
    {
        public ExerciseAlreadyExistsException() : base("Exercise with the supplied parameters already exists")
        {
        }
    }
}
