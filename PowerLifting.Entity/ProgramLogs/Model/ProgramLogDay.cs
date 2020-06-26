using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerLifting.Entity.ProgramLogs.Model
{
    public class ProgramLogDay
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        [ForeignKey("ProgramLog")]
        public int ProgramLogId { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public int DayNo { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public virtual IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}