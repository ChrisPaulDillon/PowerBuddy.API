using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.ProgramLogs
{
    public class ProgramLogInputScratchDTO
    {
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public string CustomName { get; set; }
        public bool Active { get; set; } = true;
        public IEnumerable<ProgramLogWeekDTO> ProgramLogWeeks { get; set; }
    }
}
