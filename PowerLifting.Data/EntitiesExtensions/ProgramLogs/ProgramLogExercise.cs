using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.Exercises;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public partial class ProgramLogExercise
    {
        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<ProgramLogRepScheme> ProgramLogRepSchemes { get; set; }
    }
}
