namespace PowerLifting.Data.Entities
{
    public partial class TemplateRepScheme
    {
        public int TemplateRepSchemeId { get; set; }
        public int TemplateExerciseId { get; set; }
        public decimal? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NoOfReps { get; set; } //minimum number of reps to be performed
        public decimal WeightLifted { get; set; }
        public bool IsBackOffSet { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
    }
}