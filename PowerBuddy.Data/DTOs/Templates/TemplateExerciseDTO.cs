﻿using System.Collections.Generic;
using PowerBuddy.Data.DTOs.Exercises;

namespace PowerBuddy.Data.DTOs.Templates
{
    public class TemplateExerciseDTO
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public int NoOfSets { get; set; }
        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public string RepSchemeType { get; set; } //ramped, fixed
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }

        public virtual ExerciseDTO Exercise { get; set; }
        public virtual IEnumerable<TemplateRepSchemeDTO> TemplateRepSchemes { get; set; }
    }
}