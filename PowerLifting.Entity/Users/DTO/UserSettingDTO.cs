namespace PowerLifting.Service.UserSettings.DTO
{
    public class UserSettingDTO
    {
        public int UserSettingId { get; set; }
        public string UserId { get; set; }
        public bool UsingMetric { get; set; }
        public double BodyWeight { get; set; }
    }
}
