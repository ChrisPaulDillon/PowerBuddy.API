using System;

namespace PowerLifting.Data.Exceptions.Account
{
    public class FriendRequestNotFoundException : Exception
    {
        public FriendRequestNotFoundException() : base("FriendRequest not found with parameters supplied") { }
    }
}