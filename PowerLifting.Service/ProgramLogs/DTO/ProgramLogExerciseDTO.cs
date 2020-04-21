using System.Collections.Generic;

namespace PowerLifting.Service.ProgramLogs.DTO
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

        public ICollection<ProgramLogRepSchemeDTO> ProgramLogRepSchemes { get; set; } //Stores the number of reps for each set
    }
}