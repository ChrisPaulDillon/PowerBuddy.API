﻿using System;
using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Templates;

namespace PowerBuddy.Data.DTOs.ProgramLogs
{
    public class ProgramLogTemplateInputDTO
    {
        public string UserId { get; set; }
        public int TemplateProgramId { get; set; }
        public int NoOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public int DayCount { get; set; }
        public IEnumerable<ProgramLogWeekDTO> ProgramLogWeeks { get; set; }
        public IEnumerable<TemplateWeightInputDTO> WeightInputs { get; set; }
        public IEnumerable<TemplateWeightInputDTO> IncrementalWeightInputs { get; set; }
        public int RepeatProgramCount { get; set; }
    }
}
