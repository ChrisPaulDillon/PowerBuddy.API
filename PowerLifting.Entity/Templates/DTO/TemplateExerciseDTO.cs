﻿using System.Collections.Generic;
using PowerLifting.Entity.System.Exercises.DTOs;
using PowerLifting.Service.TemplatePrograms.Model;

namespace PowerLifting.Service.TemplatePrograms.DTO
{
    public class TemplateExerciseDTO
    {
        public int TemplateExerciseId { get; set; }
        public int TemplateDayId { get; set; }
        public int ExerciseId { get; set; }
        public double? Percentage { get; set; }
        public int NoOfSets { get; set; }
        public string RepSchemeFormat { get; set; } // 3x5, 4x5
        public string RepSchemeType { get; set; } //ramped, fixed
        public bool HasBackOffSets { get; set; }
        public string BackOffSetFormat { get; set; }

        public virtual ExerciseDTO Exercise { get; set; }
        public virtual ICollection<TemplateRepSchemeDTO> TemplateRepSchemes { get; set; }
    }
}