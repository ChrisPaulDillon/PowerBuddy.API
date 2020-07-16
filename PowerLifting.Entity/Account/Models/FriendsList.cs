using System;
namespace PowerLifting.Entity.Account.Models
{
    public class FriendsList
    {
        public int FriendsListId { get; set; }
        public string UserFromId { get; set; }
        public string UserToId { get; set; }
        public bool? HasAccepted { get; set; }
    }
}
