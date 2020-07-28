namespace PowerLifting.Data.DTOs.Account
{
    public class UserSettingDTO
    {
        public int UserSettingId { get; set; }
        public string UserId { get; set; }
        public bool UsingMetric { get; set; }
        public double BodyWeight { get; set; }
        public bool ActivateQuotes { get; set; } = true;
    }
}
