using System;
using System.Collections.Generic;

namespace PowerLifting.Service.ProgramLogs.DTO
{
    public class ProgramLogDayDTO
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public int DayNo { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<ProgramLogExerciseDTO> ProgramLogExercises { get; set; }
    }
}