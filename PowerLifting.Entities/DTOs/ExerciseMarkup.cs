﻿using PowerLifting.Entities.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.DTOs
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class ExerciseMarkupDTO
    {
        public int ExerciseMarkupId { get; set; }
        public int ProgramLogId { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
        public DateTime LiftingDate { get; set; }
        public int NumOfSets { get; set; }
        public ICollection<IndividualSetDTO> IndividualSets { get; set; }  //Stores the number of reps for each set
    }
}
