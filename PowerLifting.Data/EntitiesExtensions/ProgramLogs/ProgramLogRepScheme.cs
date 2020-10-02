using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public partial class ProgramLogRepScheme
    {
        public ProgramLog ProgramLog { get; set; }
        public ProgramLogExercise ProgramLogExercise { get; set; }
    }
}
