namespace PowerLifting.Data.Entities.Tonnage
{
    public partial class TonnageWeek
    {
        public int TonnageWeekId { get; set; }
        public string UserId { get; set; }
        public int ProgramLogId { get; set; }
        public int ProgramLogWeekId { get; set; }
        public int ExerciseId { get; set; }
        public decimal WeekTonnage { get; set; }
    }
}
