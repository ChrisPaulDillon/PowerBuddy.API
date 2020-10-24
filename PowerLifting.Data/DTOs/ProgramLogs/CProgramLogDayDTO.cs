using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class CProgramLogDayDTO
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public bool Completed { get; set; }
        public virtual IEnumerable<CProgramLogExerciseDTO> ProgramLogExercises { get; set; }
    }
}
