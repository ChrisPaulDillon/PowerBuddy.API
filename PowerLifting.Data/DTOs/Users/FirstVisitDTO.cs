namespace PowerLifting.Data.DTOs.Users
{
    public class FirstVisitDTO
    {
        public string UserId { get; set; }
        public string LiftingLevel { get; set; }
        public string Gender { get; set; }
        public decimal BenchPressWeight { get; set; }
        public decimal SquatWeight { get; set; }
        public decimal DeadliftWeight { get; set; }
        public decimal OverheadPressWeight { get; set; }

    }
}
