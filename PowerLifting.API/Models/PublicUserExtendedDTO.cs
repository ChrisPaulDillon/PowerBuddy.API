using System;
using PowerLifting.Data.DTOs.Account;

namespace PowerLifting.API.Models
{
    public class PublicUserExtendedDTO : PublicUserDTO
    {
        public bool PendingFriendRequest { get; set; }
    }
}
