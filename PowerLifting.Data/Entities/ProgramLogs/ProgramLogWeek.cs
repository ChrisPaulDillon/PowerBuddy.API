using System;
using System.Collections.Generic;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public class ProgramLogWeek
    {
        public int ProgramLogWeekId { get; set; }
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public int WeekNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ProgramLogDay> ProgramLogDays { get; set; }
    }
}