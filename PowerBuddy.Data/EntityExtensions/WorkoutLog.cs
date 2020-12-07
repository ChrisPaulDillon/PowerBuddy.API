using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutLog
    {
        public IEnumerable<WorkoutDay> WorkoutDays { get; set; }
    }
}
