using System;
using PowerLifting.Data.Entities;

namespace PowerLifting.API.Models
{
    public class FriendsListExtended : FriendsListAssoc
    {
        public string UserName { get; set; }
    }
}
