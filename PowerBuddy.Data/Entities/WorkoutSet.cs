namespace PowerBuddy.Data.Entities
{
    public class WorkoutSet
    {
        public int WorkoutSetId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int NoOfReps { get; set; }
        public decimal WeightLifted { get; set; }
        public string Comment { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
        public int? RepsCompleted { get; set; }
        public int? LiftingStatAuditId { get; set; }
    }
}
