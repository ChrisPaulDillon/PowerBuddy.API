﻿using System.Collections.Generic;

namespace PowerLifting.Data.Entities.Templates
{
    public class TemplateWeek
    {
        public int TemplateWeekId { get; set; }
        public int TemplateId { get; set; }
        public int WeekNo { get; set; }
        public virtual IEnumerable<TemplateDay> TemplateDays { get; set; }
    }
}