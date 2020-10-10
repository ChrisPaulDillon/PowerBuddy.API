namespace PowerLifting.Data.DTOs.Tonnage
{
    public class TonnageWeekDTO
    {
        public int TonnageWeekId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal WeekTonnage { get; set; }
    }
}