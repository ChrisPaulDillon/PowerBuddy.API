using System;
using System.Collections.Generic;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class ProgramLogInputDTO
    {
        public string UserId { get; set; }
        public string CustomName { get; set; }
        public int? TemplateProgramId { get; set; }
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Active { get; set; }
        public int DayCount { get; set; }
        public IEnumerable<CProgramLogWeekDTO> ProgramLogWeeks { get; set; }
        public Dictionary<int, string> ProgramDayOrder { get; set; }
    }
}
