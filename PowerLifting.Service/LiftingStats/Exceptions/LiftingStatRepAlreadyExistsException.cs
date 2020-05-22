using System;
namespace PowerLifting.Service.LiftingStats.Exceptions
{
    public class LiftingStatAlreadyExistsException : Exception
    {
        public LiftingStatAlreadyExistsException() : base("The rep range and exercise provided already exists for the given user")
        {
        }
    }
}
