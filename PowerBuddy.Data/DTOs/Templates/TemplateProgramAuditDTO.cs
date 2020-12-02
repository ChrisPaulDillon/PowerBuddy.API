using System;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateProgramAuditDTO
    {
        public int TemplateProgramId { get; set; }
        public string Username { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
