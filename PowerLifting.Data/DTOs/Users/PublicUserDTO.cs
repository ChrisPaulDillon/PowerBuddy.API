namespace PowerLifting.Data.DTOs.Account
{
    public class PublicUserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string SportType { get; set; }
        public bool IsPublic { get; set; }
        public int Rights { get; set; }
        public string Gender { get; set; }
        public string LiftingLevel { get; set; }
    }
}
