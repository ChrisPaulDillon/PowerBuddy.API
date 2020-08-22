using System;
using System.Collections.Generic;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    public class ProgramLogDay
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public bool Completed { get; set; }
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
        public virtual ProgramLogWeek ProgramLogWeek { get; set; }
    }
}