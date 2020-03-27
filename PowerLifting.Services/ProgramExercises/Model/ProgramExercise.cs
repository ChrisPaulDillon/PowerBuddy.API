using System.Collections.Generic;
using Powerlifting.Services.IndividualSets.Model;

namespace Powerlifting.Service.ProgramExercises.Model
{
    /// <summary>
    /// ProgramExercise reprents on a fixed program template, a given exercise, its set, rep and percentage scemema
    /// </summary>
    public class ProgramExercise
    {
        public int ProgramExerciseId { get; set; }
        public int ProgramTemplateId { get; set; }
        public string ExerciseName { get; set; }
        public string Percentage { get; set; }
        public int WeekNumber { get; set; }
        public int DayNumber { get; set; }
        public int NoOfSets { get; set; }
        public virtual ICollection<IndividualSet> IndividualSets { get; set; }
    }
}
