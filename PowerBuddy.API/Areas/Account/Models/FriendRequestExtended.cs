using PowerBuddy.Data.Entities;

namespace PowerBuddy.API.Areas.Account.Models
{
    public class FriendRequestExtended : FriendRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
