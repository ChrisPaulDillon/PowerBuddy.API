using System;
using PowerLifting.Data.DTOs.Account;
using PowerLifting.Data.DTOs.Users;

namespace PowerLifting.API.Models
{
    public class PublicUserExtendedDTO : PublicUserDTO
    {
        public bool PendingFriendRequest { get; set; }
    }
}
