using System;
using System.Collections;
using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutLog
    {
        public int WorkoutLogId { get; set; }
        public string CustomName { get; set; }
        public string UserId { get; set; }
        public int? TemplateProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}
