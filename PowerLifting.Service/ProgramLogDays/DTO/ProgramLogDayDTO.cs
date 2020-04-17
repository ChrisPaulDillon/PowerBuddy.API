using System;
using System.Collections.Generic;
using PowerLifting.Services.ProgramLogExercises.DTO;

namespace PowerLifting.Service.ProgramLogDays.DTO
{
    public class ProgramLogDayDTO
    {
        public int ProgramDayId { get; set; }
        public int ProgramWeekId { get; set; }
        public string UserId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public IEnumerable<ProgramLogExerciseDTO> ProgramLogExercises { get; set; }
    }
}
