using System;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.API.Models
{
    public class FriendsListExtended : FriendsListAssoc
    {
        public string UserName { get; set; }
    }
}
