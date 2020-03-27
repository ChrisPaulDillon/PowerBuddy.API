using System;
using System.Collections.Generic;
using PowerLifting.ExerciseMarkups.Model;

namespace Powerlifting.Services.ProgramLogs
{
    /// <summary>
    /// ProgramLog details information based on that specific weightlifting cycle
    /// Such as start, end date, the type of program and the days of the week the user is doing it
    /// </summary>
    public class ProgramLog
    {
        public int ProgramLogId { get; set; }
        public int UserId { get; set; }
        public int ProgramTemplateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDaysLifting { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public ICollection<ExerciseMarkup> ExeciseMarkups { get; set; }

    }
}
