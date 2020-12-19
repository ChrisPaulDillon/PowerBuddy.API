using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutTemplate
    {
        public IEnumerable<ProgramLogExercise> WorkoutExercises { get; set; }
    }
}
