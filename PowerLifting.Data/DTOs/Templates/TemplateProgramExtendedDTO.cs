﻿using System;
using System.Collections.Generic;

namespace PowerLifting.Data.DTOs.Templates
{
    public class TemplateProgramExtendedDTO
    {
        public int TemplateProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NoOfWeeks { get; set; }
        public int NoOfDaysPerWeek { get; set; }
        public string TemplateType { get; set; } //incremental, percentage based
        public string WeightProgressionType { get; set; } //incremental, percentage based

        public virtual IEnumerable<TemplateWeekDTO> TemplateWeeks { get; set; }
        public IEnumerable<TemplateExerciseCollectionDTO> TemplateExerciseCollection { get; set; }
    }
}
