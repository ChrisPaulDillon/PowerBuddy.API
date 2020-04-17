using System;
using System.Collections.Generic;
using PowerLifting.ProgramLogExercises.Model;

namespace PowerLifting.Service.ProgramLogDays.Model
{
    public class ProgramLogDay
    {
        public int ProgramDayId { get; set; }
        public int ProgramWeekId { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}
