using System;

namespace Powerlifting.Services.ProgramLogSets.DTO
{
    public class ProgramLogSetDTO
    {
        public int ProgramLogSetId { get; set; }
        public int? ExerciseMarkupId { get; set; }
        public double Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
