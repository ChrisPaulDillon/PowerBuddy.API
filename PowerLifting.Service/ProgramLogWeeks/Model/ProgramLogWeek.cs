using System;
using System.Collections.Generic;
using PowerLifting.Service.ProgramLogDays.Model;

namespace PowerLifting.Service.ProgramLogWeeks.Model
{
    public class ProgramLogWeek
    {
        public int ProgramLogWeekId { get; set; }
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ProgramLogDay> ProgramLogDays { get; set; }
    }
}
