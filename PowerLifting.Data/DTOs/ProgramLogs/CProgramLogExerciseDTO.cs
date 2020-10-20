﻿using System.Collections.Generic;

namespace PowerLifting.Data.DTOs.ProgramLogs
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class CProgramLogExerciseDTO
    {
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }

        public decimal? Weight { get; set; } //only used when repSchemeType is set to 'fixed'
        public int? Reps { get; set; } //only used when repSchemeType is set to 'fixed'

        public virtual IEnumerable<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
    }
}