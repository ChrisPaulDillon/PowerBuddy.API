using System;
using System.Collections;
using System.Collections.Generic;
using PowerLifting.Data.DTOs.ProgramLogs;

namespace PowerLifting.API.API.Areas.ProgramLog.Models
{
    public class ProgramLogWithTemplateDTO : ProgramLogDTO
    {
        public string TemplateName { get; set; }
        public IEnumerable<DateTime> LogDates { get; set; }
    }
}
