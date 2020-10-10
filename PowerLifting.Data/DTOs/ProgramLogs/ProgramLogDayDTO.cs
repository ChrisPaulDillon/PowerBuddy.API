using System;
using System.Collections.Generic;
using PowerLifting.Data.DTOs.Tonnage;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class ProgramLogDayDTO
    {
        public int ProgramLogDayId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public bool Completed { get; set; }
        public int? TonnageDayId { get; set; }
        public virtual IEnumerable<ProgramLogExerciseDTO> ProgramLogExercises { get; set; }
        public TonnageDayDTO TonnageDay { get; set; }
    }
}