namespace PowerLifting.Entity.ProgramLogs.DTO
{
    public class MarkupProgramLogRepSchemeDTO
    {
        public int SetNo { get; set; }
        public int NoOfReps { get; set; }
        public double WeightLifted { get; set; }
        public double? Percentage { get; set; }
        public string Comment { get; set; }
        public bool IsBackOffSet { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
    }
}