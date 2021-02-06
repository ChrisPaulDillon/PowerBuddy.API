using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Commands.Workouts.Models
{
    public class WorkoutWeekSummaryDto
    {
        public string TemplateName { get; set; }
        public int WeekNo { get; set; }
        public IEnumerable<WorkoutDaySummaryDto> WorkoutDays { get; set; }
    }
}
