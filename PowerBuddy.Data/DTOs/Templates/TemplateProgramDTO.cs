namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateProgramDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int NoOfDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //incremental, percentage based
        public string WeightProgressionType { get; set; } //incremental, percentage based
    }
}