using Powerlifting.Service.Exercises.Model;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using System;
using System.Collections.Generic;

namespace PowerLifting.ProgramLogExercises.Model
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public class ProgramLogExercise
    {
        public int ProgramLogExerciseId { get; set; }
        public int ProgramLogId { get; set; }
        public string ExerciseName { get; set; }
        public DateTime LiftingDate { get; set; }
        public int NumOfSets { get; set; }
        public ICollection<ProgramLogRepScheme> ProgramLogRepSchemes { get; set; }  //Stores the number of reps for each set
    }
}
