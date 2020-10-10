﻿using System.Collections.Generic;

namespace PowerLifting.Data.Entities
{
    public partial class ProgramLogExercise
    {
        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<ProgramLogRepScheme> ProgramLogRepSchemes { get; set; }
        public virtual TonnageDayExercise TonnageDayExercise { get; set; }
    }
}