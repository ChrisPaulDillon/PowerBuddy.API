namespace PowerLifting.Data.Entities
{
    public partial class TonnageWeekExercise
    {
        public int TonnageWeekExerciseId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal WeekTonnage { get; set; }
    }
}
