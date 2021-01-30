using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.ProgramLogs;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutLogInputScratchDTO
    {
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public string UserId { get; set; }
        public string CustomName { get; set; }
        public IEnumerable<WorkoutDayDTO> WorkoutDays { get; set; }
    }
}
