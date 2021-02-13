namespace PowerBuddy.Data.Entities
{
    /// <summary>
    /// TemplateExercise represents on a fixed program template, a given exercise,
    /// its set, rep and percentage schema
    /// </summary>
    public partial class TemplateExercise
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }
    }
}