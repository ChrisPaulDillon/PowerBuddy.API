using System;

namespace PowerBuddy.Data.Exceptions.Account
{
    public class FriendRequestNotFoundException : Exception
    {
        public FriendRequestNotFoundException() : base("FriendRequest not found with parameters supplied") { }
    }
}