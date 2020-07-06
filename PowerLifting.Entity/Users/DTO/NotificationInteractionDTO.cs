using System;
namespace PowerLifting.Entity.Users.DTO
{
    public class NotificationInteractionDTO
    {
        public int NotificationInteractionId { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool HasRead { get; set; }
    }
}
