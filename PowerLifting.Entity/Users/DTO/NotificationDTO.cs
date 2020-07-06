using System;
namespace PowerLifting.Entity.Users.DTO
{
    public class NotificationDTO
    {
        public string NotificationId { get; set; }
        public string NotificationText { get; set; }
        public bool HasRead { get; set; }
    }
}
