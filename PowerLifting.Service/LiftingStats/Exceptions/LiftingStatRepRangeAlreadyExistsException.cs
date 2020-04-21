using System;
namespace PowerLifting.Service.LiftingStats.Exceptions
{
    public class LiftingStatRepRangeAlreadyExistsException : Exception
    {
        public LiftingStatRepRangeAlreadyExistsException() : base("The rep range provided already exists for a given user")
        {
        }
    }
}
