using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutDay
    {
        public User User { get; set; }
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
        public WorkoutLog WorkoutLog { get; set; }
    }
}
