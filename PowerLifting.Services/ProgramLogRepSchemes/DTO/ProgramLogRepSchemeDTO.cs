using System;

namespace Powerlifting.Services.ProgramLogRepSchemes.DTO
{
    public class ProgramLogRepSchemeDTO
    {
        public int ProgramLogRepSchemesId { get; set; }
        public int? ProgramLogExerciseId { get; set; }
        public double Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
