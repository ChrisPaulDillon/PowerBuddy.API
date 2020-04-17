using System;
using System.Collections.Generic;

namespace PowerLifting.Service.ProgramLogs.DTO
{
    /// <summary>
    ///     Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    ///     Always unique to the user as this will allow customisation
    /// </summary>
    public class ProgramLogExerciseDTO
    {
        public int ProgramLogExerciseId { get; set; }
        public int ProgramLogId { get; set; }
        public string ExerciseName { get; set; }
        public DateTime Date { get; set; }
        public int NumOfSets { get; set; }
        public string Comment { get; set; }

        public ICollection<ProgramLogRepSchemeDTO>
            ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
    }
}