using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.ProgramLogs.Workouts
{
    public class WorkoutDaySummaryDTO
    {
        public int ProgramLogDayId { get; set; }
        public DateTime Date { get; set; }
        public int PersonalBestCount { get; set; }
        public IEnumerable<WorkoutExerciseSummaryDTO> WorkoutExerciseSummaries { get; set; }

    }
}
