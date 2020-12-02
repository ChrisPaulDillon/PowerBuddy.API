using System;

namespace PowerBuddy.Data.Entities
{
    public partial class TemplateProgramAudit
    {
        public int TemplateProgramAuditId { get; set; }
        public int TemplateProgramId { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
