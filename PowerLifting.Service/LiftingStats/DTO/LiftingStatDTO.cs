namespace Powerlifting.Service.LiftingStats.DTO
{
    public class LiftingStatDTO
    {
        public int LiftingStatId { get; set; }
        public string UserId { get; set; }
        public double? Percentage { get; set; }
        public double BenchWeight { get; set; }
        public double SquatWeight { get; set; }
        public double DeadliftWeight { get; set; }
    }
}
