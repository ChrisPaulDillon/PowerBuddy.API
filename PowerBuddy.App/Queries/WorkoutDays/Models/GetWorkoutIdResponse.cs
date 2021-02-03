namespace PowerBuddy.App.Queries.WorkoutDays.Models
{
    public class GetWorkoutIdResponse
    {
        public int WorkoutDayId { get; set; }
        public int? WorkoutLogId { get; set; }
        public string TemplateName { get; set; }
        public int WeekNo { get; set; }
    }
}
