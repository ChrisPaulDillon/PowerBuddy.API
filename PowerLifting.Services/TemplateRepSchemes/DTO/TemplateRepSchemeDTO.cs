using System;
namespace PowerLifting.Services.TemplateRepSchemes.DTO
{
    public class TemplateRepSchemeDTO
    {
        public int TemplateRepSchemeId { get; set; }
        public int TemplateExerciseId { get; set; } //Is this set for a fixed program or a user?
        public double? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
