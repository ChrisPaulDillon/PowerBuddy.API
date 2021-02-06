namespace PowerBuddy.Data.Dtos.Account
{
    public class EditProfileDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BodyWeight { get; set; }
        public bool QuotesEnabled { get; set; }
        public bool UsingMetric { get; set; }
    }
}
