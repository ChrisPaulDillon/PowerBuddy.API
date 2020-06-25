using System;
using PowerLifting.Entity.ProgramLogs.DTO;

namespace PowerLifting.API.API.Areas.ProgramLog.Models
{
    public class ProgramLogWithTemplateDTO : ProgramLogDTO
    {
        public string TemplateName { get; set; }
    }
}
