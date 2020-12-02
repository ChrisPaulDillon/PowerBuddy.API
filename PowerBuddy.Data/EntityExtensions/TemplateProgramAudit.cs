using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateProgramAudit
    {
        public User User { get; set; }
        public TemplateProgram TemplateProgram { get; set; }
    }
}
