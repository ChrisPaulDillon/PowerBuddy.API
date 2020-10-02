using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public partial class ProgramLogDay
    {
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}
