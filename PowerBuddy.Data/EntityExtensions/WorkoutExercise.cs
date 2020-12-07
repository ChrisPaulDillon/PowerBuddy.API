using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutExercise
    {
        public IEnumerable<WorkoutSet> WorkoutSets { get; set; }
    }
}
