using System;

namespace Powerlifting.Services.ProgramLogRepSchemes.DTO
{
    public class ProgramLogRepSchemeDTO
    {
        public double Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
