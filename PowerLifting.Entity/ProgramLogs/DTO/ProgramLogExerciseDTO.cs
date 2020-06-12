using System.Collections.Generic;
using PowerLifting.Entity.System.Exercises.DTOs;

namespace PowerLifting.Entity.ProgramLogs.DTO
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

        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public string RepSchemeType { get; set; } //ramped, fixed
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }
        public bool Completed { get; set; }

        public decimal? Weight { get; set; } //only used when repSchemeType is set to 'fixed'
        public int? Reps { get; set; } //only used when repSchemeType is set to 'fixed'

        public virtual ExerciseDTO Exercise { get; set; }
        public virtual ICollection<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
    }
}