﻿using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.ProgramLogs
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class ProgramLogExerciseDTO
    {
        public int ProgramLogExerciseId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public int ProgramLogExerciseTonnageId { get; set; }
        public string ExerciseName { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public decimal? Weight { get; set; } //only used when repSchemeType is set to 'fixed'
        public int? Reps { get; set; } //only used when repSchemeType is set to 'fixed'
        public virtual ProgramLogExerciseTonnageDTO ProgramLogExerciseTonnageDTO { get; set; }
        public virtual ICollection<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; }
    }
}