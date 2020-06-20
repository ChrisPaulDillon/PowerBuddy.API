namespace PowerLifting.Service.UserSettings.Model
{
    /// <summary>
    /// Used to store specific settings about the user such as their bodyweight,
    /// unit measurement preferences etc.
    /// </summary>
    public class UserSetting
    {
        public int UserSettingId { get; set; }
        public string UserId { get; set; }
        public bool UsingMetric { get; set; }
        public double BodyWeight { get; set; }
        public bool ActiveQuotes { get; set; } = true;
    }
}
