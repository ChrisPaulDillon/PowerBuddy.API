﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.Tonnage
{
    public partial class TonnageDay
    {
        public int TonnageDayId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public decimal DayTonnage { get; set; }
    }
}
