namespace PowerLifting.Entity.Account.DTOs
{
    public class FriendsListDTO
    {
        public int FriendsListId { get; set; }
        public string UserFromId { get; set; }
        public string UserToId { get; set; }
        public bool HasAccepted { get; set; }
    }
}
