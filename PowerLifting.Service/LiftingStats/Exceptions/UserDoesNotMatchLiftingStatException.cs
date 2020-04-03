using System;
namespace PowerLifting.Service.LiftingStats.Exceptions
{
    public class UserDoesNotMatchLiftingStatException : Exception
    {
        public UserDoesNotMatchLiftingStatException(string message) : base(message)
        {
        }
    }
}
