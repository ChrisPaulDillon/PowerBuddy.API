using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Entities
{
    public partial class Exercise
    {
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssoc> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSport> ExerciseSports { get; set; }
    }
}
