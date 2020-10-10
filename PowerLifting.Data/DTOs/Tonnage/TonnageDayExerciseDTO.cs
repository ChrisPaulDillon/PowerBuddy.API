namespace PowerLifting.Data.DTOs.Tonnage
{
    public class TonnageDayExerciseDTO
    {
        public int TonnageDayExerciseId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ProgramLogDayId { get; set; }
        public int ExerciseId { get; set; }
        public decimal DayTonnage { get; set; }
    }
}
