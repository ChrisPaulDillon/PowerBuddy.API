using System;
using System.Collections.Generic;

namespace PowerLifting.Service.ProgramLogs.Model
{
    public class ProgramLogDay
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}