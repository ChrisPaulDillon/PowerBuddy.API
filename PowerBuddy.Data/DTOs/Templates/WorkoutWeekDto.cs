using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class WorkoutWeekDto
    {
        public int WeekNo { get; set; }
        public IEnumerable<WorkoutDayDto> WorkoutDays { get; set; }
    }
}
