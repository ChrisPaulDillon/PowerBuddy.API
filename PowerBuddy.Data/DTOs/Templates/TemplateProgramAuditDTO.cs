using System;

namespace PowerBuddy.Data.Dtos.Templates
{
    public class TemplateProgramAuditDto
    {
        public int TemplateProgramId { get; set; }
        public string Username { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
