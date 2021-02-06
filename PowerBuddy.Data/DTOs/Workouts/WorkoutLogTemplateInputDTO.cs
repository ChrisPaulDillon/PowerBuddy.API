using System;
using System.Collections.Generic;
using PowerBuddy.Data.Dtos.Templates;

namespace PowerBuddy.Data.Dtos.Workouts
{
    public class WorkoutLogTemplateInputDto
    {
        public string UserId { get; set; }
        public int TemplateProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public int DayCount { get; set; }
        public string CustomName { get; set; }
        public IEnumerable<TemplateWeightInputDto> WeightInputs { get; set; }
        public IEnumerable<TemplateWeightInputDto> IncrementalWeightInputs { get; set; }
        public int RepeatProgramCount { get; set; }
    }
}
