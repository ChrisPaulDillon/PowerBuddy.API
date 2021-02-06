using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.ProgramLogs;

namespace PowerBuddy.Data.Dtos.Workouts
{
    public class WorkoutLogInputScratchDto
    {
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public string UserId { get; set; }
        public string CustomName { get; set; }
        public IEnumerable<WorkoutDayDto> WorkoutDays { get; set; }
    }
}
