using System;
using System.Collections.Generic;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.DTO
{
    public class ProgramLogWeekDTO
    {
        public int ProgramLogWeekId { get; set; }
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ProgramLogDay> ProgramLogDays { get; set; }
    }
}