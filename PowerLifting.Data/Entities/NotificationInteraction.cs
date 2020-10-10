namespace PowerLifting.Data.Entities
{
    public partial class NotificationInteraction
    {
        public int NotificationInteractionId { get; set; }
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public bool HasRead { get; set; }
    }
}
