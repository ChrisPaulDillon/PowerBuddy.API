using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.ProgramLogs.Workouts;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutDaySummaryDTO
    {
        public int WorkoutDayId { get; set; }
        public int WeekNo { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public string TemplateName { get; set; }
        public int PersonalBestCount { get; set; }
        public int WorkoutExerciseCount { get; set; }
        public IEnumerable<WorkoutExerciseSummaryDTO> WorkoutExerciseSummaries { get; set; }
        public bool HasWorkoutData { get; set; } = true;
    }
}
