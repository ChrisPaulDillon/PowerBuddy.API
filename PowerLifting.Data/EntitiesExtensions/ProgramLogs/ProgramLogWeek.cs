using System;
using System.Collections.Generic;
using System.Text;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public partial class ProgramLogWeek
    {
        public IEnumerable<ProgramLogDay> ProgramLogDays { get; set; }
    }
}
