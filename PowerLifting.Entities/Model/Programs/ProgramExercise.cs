using System.Collections.Generic;
using PowerLifting.Entities.Model.Lookups;

namespace PowerLifting.Entities.Model.Programs
{
    public class ProgramExercise
    {
        public int ProgramExerciseId { get; set; }
        public int ProgramTypeId { get; set; }
        public int ExerciseId { get; set; }
        public int WeekNumber { get; set; }
        public string DayOfWeek { get; set; }
        public virtual ICollection<IndividualSet> IndividualSets { get; set; }
    }
}
