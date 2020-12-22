using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.MediatR.Workouts.Models
{
    public class WorkoutStatExtendedDTO
    {
        public string UserId { get; set; }
        public int LifetimeLogCount { get; set; }
        public int LifetimeDayCount { get; set; }
        public int LifetimeExerciseCount { get; set; }
        public int LifetimeExerciseCompletedCount { get; set; }
        public IEnumerable<WorkoutLog> WorkoutLogStats { get; set; }
    }
}
