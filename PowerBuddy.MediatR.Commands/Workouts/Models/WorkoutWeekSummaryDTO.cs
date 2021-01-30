using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Workouts;

namespace PowerBuddy.MediatR.Commands.Workouts.Models
{
    public class WorkoutWeekSummaryDTO
    {
        public string TemplateName { get; set; }
        public int WeekNo { get; set; }
        public IEnumerable<WorkoutDaySummaryDTO> WorkoutDays { get; set; }
    }
}
