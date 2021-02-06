using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Workouts;

namespace PowerBuddy.App.Queries.Workouts.Models
{
    public class WorkoutStatExtendedDto
    {
        public string UserId { get; set; }
        public int LifetimeLogCount { get; set; }
        public int LifetimeDayCount { get; set; }
        public int LifetimeExerciseCount { get; set; }
        public int LifetimeExerciseCompletedCount { get; set; }
        public IEnumerable<WorkoutLogStatDto> WorkoutLogStats { get; set; }
    }
}
