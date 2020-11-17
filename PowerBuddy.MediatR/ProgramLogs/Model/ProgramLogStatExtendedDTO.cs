using System.Collections.Generic;
using PowerBuddy.Data.DTOs.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogs.Model
{
    public class ProgramLogStatExtendedDTO
    {
        public string UserId { get; set; }
        public int LifetimeLogCount { get; set; }
        public int LifetimeDayCount { get; set; }
        public int LifetimeExerciseCount { get; set; }
        public int LifetimeExerciseCompletedCount { get; set; }
        public IEnumerable<ProgramLogStatDTO> ProgramLogStats { get; set; }
    }
}
