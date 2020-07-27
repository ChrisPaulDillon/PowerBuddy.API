using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Entity.ProgramLogs.Model
{
    public class ProgramLogDay
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}