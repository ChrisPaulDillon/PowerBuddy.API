﻿using System.Collections;
using System.Collections.Generic;

namespace PowerBuddy.Data.Entities
{
    public partial class WorkoutDay
    {
        public IEnumerable<ProgramLogExercise> ProgramLogExercises { get; set; }
    }
}
