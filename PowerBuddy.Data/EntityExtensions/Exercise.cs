using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class Exercise
    {
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssoc> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSport> ExerciseSports { get; set; }
        public virtual IEnumerable<LiftingStatAudit> LiftingStatAudit { get; set; }


    }
}
