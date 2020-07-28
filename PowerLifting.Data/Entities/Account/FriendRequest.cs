﻿namespace PowerLifting.Data.Entities.Account
{
    public class FriendRequest
    {
        public int FriendRequestId { get; set; }
        public string UserFromId { get; set; }
        public string UserToId { get; set; }
        public bool? HasAccepted { get; set; }
    }
}
