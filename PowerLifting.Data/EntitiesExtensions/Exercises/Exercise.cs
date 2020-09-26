using System;
using System.Collections.Generic;
using System.Text;

namespace PowerLifting.Data.Entities.Exercises
{
    public partial class Exercise
    {
        public virtual ExerciseType ExerciseType { get; set; }
        public virtual IEnumerable<ExerciseMuscleGroupAssoc> ExerciseMuscleGroups { get; set; }
        public virtual IEnumerable<ExerciseSport> ExerciseSports { get; set; }
    }
}
