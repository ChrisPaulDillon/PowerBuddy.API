using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.ProgramLogs.Workouts;

namespace PowerBuddy.Data.Dtos.Workouts
{
    public class WorkoutDaySummaryDto
    {
        public int WorkoutDayId { get; set; }
        public int WeekNo { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }
        public string TemplateName { get; set; }
        public int PersonalBestCount { get; set; }
        public int WorkoutExerciseCount { get; set; }
        public IEnumerable<WorkoutExerciseSummaryDto> WorkoutExerciseSummaries { get; set; }
        public bool HasWorkoutData { get; set; } = true;
    }
}
