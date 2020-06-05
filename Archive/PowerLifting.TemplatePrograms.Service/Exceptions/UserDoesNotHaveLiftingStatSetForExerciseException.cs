using System;
namespace PowerLifting.Service.TemplatePrograms.Exceptions
{
    public class UserDoesNotHaveLiftingStatSetForExerciseException : Exception
    {
        public UserDoesNotHaveLiftingStatSetForExerciseException() : base("User does not have all lifting stat 1RMs set for the exercises used in this template!")
        {
        }
    }
}
