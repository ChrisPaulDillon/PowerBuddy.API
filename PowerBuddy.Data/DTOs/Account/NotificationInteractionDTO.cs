namespace PowerBuddy.Data.DTOs.Account
{
    public class NotificationInteractionDTO
    {
        public int NotificationInteractionId { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool HasRead { get; set; }
    }
}
