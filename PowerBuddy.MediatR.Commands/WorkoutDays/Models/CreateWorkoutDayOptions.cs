using System;

namespace PowerBuddy.MediatR.Commands.WorkoutDays.Models
{
    public class CreateWorkoutDayOptions
    {
        public DateTime WorkoutDate { get; set; }
        public int? WorkoutLogId { get; set; }
        public int? WeekNo { get; set; }
    }
}
