using System;

namespace PowerBuddy.Data.Entities
{
    public partial class EmailTemplate
    {
        public int EmailTemplateId { get; set; }
        public string TemplateName { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
