﻿namespace PowerLifting.Data.Entities.Account
{
    public partial class FriendsListAssoc
    {
        public int FriendsListAssocId { get; set; }
        public string UserId { get; set; }
        public string OtherUserId { get; set; }
        public string OtherUserName { get; set; }
    }
}
