using System;
using PowerLifting.Entity.Account.Models;

namespace PowerLifting.API.Models
{
    public class FriendsListExtended : FriendsListAssoc
    {
        public string UserName { get; set; }
    }
}
