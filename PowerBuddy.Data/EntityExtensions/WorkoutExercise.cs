using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutExercise
    {
        public ICollection<WorkoutSet> WorkoutSets { get; set; }
        public WorkoutExerciseTonnage WorkoutExerciseTonnage { get; set; }
        public Exercise Exercise { get; set; }
    }
}
