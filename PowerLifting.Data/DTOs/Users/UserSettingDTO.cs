namespace PowerLifting.Data.DTOs.Users
{
    public class UserSettingDTO
    {
        public int UserSettingId { get; set; }
        public string UserId { get; set; }
        public bool UsingMetric { get; set; }
        public decimal BodyWeight { get; set; }
        public bool ActivateQuotes { get; set; } = true;
    }
}
