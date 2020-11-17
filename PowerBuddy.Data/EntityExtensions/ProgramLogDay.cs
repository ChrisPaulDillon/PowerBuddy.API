using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class ProgramLogDay
    {
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}
