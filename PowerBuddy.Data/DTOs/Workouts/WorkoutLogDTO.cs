using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutLogDTO
    {
        public int WorkoutLogId { get; set; }
        public string CustomName { get; set; }
        public string UserId { get; set; }
        public int? TemplateProgramId { get; set; }
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
        public IEnumerable<WorkoutDayDTO> WorkoutDays { get; set; }
        public string TemplateName { get; set; }
    }
}
