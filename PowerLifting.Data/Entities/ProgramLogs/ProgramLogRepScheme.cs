namespace PowerLifting.Data.Entities.ProgramLogs
{
    public class ProgramLogRepScheme
    {
        public int ProgramLogRepSchemeId { get; set; }
        public int ProgramLogExerciseId { get; set; }
        public int SetNo { get; set; }
        public int NoOfReps { get; set; }
        public decimal WeightLifted { get; set; }
        public decimal? Percentage { get; set; }
        public string Comment { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
        public bool Completed { get; set; }
        public int? RepsCompleted { get; set; }
        public bool? PersonalBest { get; set; }
        public ProgramLogExercise ProgramLogExercise { get; set; }
    }
}