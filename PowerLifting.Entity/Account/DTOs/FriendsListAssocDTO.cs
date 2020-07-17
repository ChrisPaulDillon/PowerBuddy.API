using System;
namespace PowerLifting.Entity.Account.DTOs
{
    public class FriendsListAssocDTO
    {
        public int FriendsListAssocId { get; set; }
        public string UserId { get; set; }
        public string OtherUserId { get; set; }
    }
}
