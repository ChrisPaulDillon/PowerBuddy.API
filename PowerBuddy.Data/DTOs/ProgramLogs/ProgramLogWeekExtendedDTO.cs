using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.ProgramLogs
{
    public class ProgramLogWeekExtendedDTO
    {
        public string CustomName { get; set; }
        public string TemplateName { get; set; }
        public int TemplateProgramId { get; set; }
        public int NoOfWeeks { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public int WeekNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<ProgramLogDayDTO> ProgramLogDays { get; set; }
    }
}
