using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutLog
    {
        public TemplateProgram TemplateProgram { get; set; }
        public IEnumerable<WorkoutDay> WorkoutDays { get; set; }
    }
}
