namespace PowerLifting.Data.DTOs.Account
{
    public class PublicUserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal BodyWeight { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
        public string MemberStatus { get; set; }
        public string Gender { get; set; }
        public string LiftingLevel { get; set; }
    }
}
