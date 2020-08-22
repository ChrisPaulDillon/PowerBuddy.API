using System;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.API.Models
{
    public class FriendRequestExtended : FriendRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
