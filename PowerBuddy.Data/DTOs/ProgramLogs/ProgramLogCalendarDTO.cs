using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.ProgramLogs
{
    public class ProgramLogCalendarDTO
    {
        public IEnumerable<DateTime> WorkoutDates { get; set; }
        public IEnumerable<DateTime> PersonalBestDates { get; set; }
    }
}
