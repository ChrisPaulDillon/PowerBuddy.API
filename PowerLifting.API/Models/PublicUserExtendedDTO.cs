using System;
using PowerLifting.Entity.Users.DTO;

namespace PowerLifting.API.Models
{
    public class PublicUserExtendedDTO : PublicUserDTO
    {
        public bool PendingFriendRequest { get; set; }
    }
}
