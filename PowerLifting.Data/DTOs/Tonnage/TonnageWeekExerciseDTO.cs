namespace PowerLifting.Data.DTOs.Tonnage
{
    public class TonnageWeekExerciseDTO
    {
        public int TonnageWeekExerciseId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal WeekTonnage { get; set; }
    }
}