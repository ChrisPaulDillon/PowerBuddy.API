namespace PowerLifting.Data.DTOs.Account
{
    public class FriendRequestDTO
    {
        public int FriendRequestId { get; set; }
        public string UserFromId { get; set; }
        public string UserToId { get; set; }
        public bool HasAccepted { get; set; }
    }
}
