using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutDay
    {
        public IEnumerable<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
