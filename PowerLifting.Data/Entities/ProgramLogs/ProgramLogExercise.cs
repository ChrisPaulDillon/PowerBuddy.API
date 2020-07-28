using System.Collections.Generic;
using PowerLifting.Data.Entities.System;

namespace PowerLifting.Data.Entities.ProgramLogs
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class ProgramLogExercise
    {
        public int ProgramLogExerciseId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }
        public bool? PersonalBest { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual ICollection<ProgramLogRepScheme> ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
        public virtual ProgramLogDay ProgramLogDay { get; set; }
    }
}