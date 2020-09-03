using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    public class ProgramLogStatDTO
    {
        public int ProgramLogId { get; set; }
        public string CustomName { get; set; }
        public string UserId { get; set; }
        public int TemplateProgramId { get; set; }
        public string TemplateName { get; set; }
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Active { get; set; }
        public IEnumerable<ProgramLogWeekDTO> ProgramLogWeeks { get; set; }
        public int ExerciseVarianceCount { get; set; }
        public int DayCount { get; set; }
        public int ExerciseCount { get; set; }
        public int ExerciseCompletedCount { get; set; }
    }
}
