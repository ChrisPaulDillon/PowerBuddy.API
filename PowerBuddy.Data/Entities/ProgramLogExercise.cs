namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// Represents a given lift, its sets, weight and reps lifted on a given day for that particular exercise.
    /// Always unique to the user as this will allow customisation
    /// </summary>
    public partial class ProgramLogExercise
    {
        public int ProgramLogExerciseId { get; set; }
        public int? ProgramLogDayId { get; set; }
        public int? WorkoutTemplateId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string Comment { get; set; }
        public bool? PersonalBest { get; set; }
        public int ProgramLogExerciseTonnageId { get; set; }
    }
}