using System;
using System.Collections.Generic;

namespace PowerLifting.Entity.ProgramLogs.DTO
{
    public class CProgramLogDTO
    {
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Active { get; set; }
        public int NoOfDays { get; set; }
        public IEnumerable<ProgramLogWeekDTO> ProgramLogWeeks { get; set; }
    }
}
