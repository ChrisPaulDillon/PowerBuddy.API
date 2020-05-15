﻿using System;
using System.Collections.Generic;

namespace PowerLifting.Service.ProgramLogs.DTO
{
    public class ProgramLogWeekDTO
    {
        public int ProgramLogWeekId { get; set; }
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public int WeekNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<ProgramLogDayDTO> ProgramLogDays { get; set; }
    }
}