using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.Tonnage
{
    public class TonnageDayDTO
    {
        public int TonnageDayId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public decimal DayTonnage { get; set; }
    }
}
