namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateRepSchemeDto
    {
        public int TemplateRepSchemeId { get; set; }
        public int TemplateExerciseId { get; set; } //Is this set for a fixed program or a user?
        public decimal? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NoOfReps { get; set; }
        public decimal WeightLifted { get; set; }
        public bool IsBackOffSet { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
    }
}