using System;

namespace PowerBuddy.Data.Exceptions.LiftingStats
{
    public class LiftingStatAlreadyExistsException : Exception
    {
        public LiftingStatAlreadyExistsException() : base("The rep range and exercise provided already exists for the given user")
        {
        }
    }
}
