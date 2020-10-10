using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class ProgramLogDay
    {
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}
