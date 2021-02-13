namespace PowerBuddy.Data.Entities
{
    public partial class TemplateDay
    {
        public int TemplateDayId { get; set; }
        public int TemplateProgramId { get; set; }
        public int WeekNo { get; set; }
        public int DayNo { get; set; }
    }
}