using System;
using System.Collections;
using System.Collections.Generic;
using PowerLifting.Entity.ProgramLogs.DTO;

namespace PowerLifting.API.API.Areas.ProgramLog.Models
{
    public class ProgramLogWithTemplateDTO : ProgramLogDTO
    {
        public string TemplateName { get; set; }
        public IEnumerable<DateTime> LogDates { get; set; }
    }
}
