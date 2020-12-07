using System;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutDay
    {
        public int WorkoutDayId { get; set; }
        public int? WorkoutLogId { get; set; }
        public int? WeekNo { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }
    }
}