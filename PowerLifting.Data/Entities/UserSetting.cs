namespace PowerLifting.Data.Entities
{
    /// <summary>
    /// Used to store specific settings about the user such as their bodyweight,
    /// unit measurement preferences etc.
    /// </summary>
    public partial class UserSetting
    {
        public int UserSettingId { get; set; }
        public string UserId { get; set; }
        public bool UsingMetric { get; set; }
        public decimal BodyWeight { get; set; }
        public bool ActiveQuotes { get; set; } = true;
    }
}
