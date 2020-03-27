using System;

namespace Powerlifting.Services.IndividualSets.DTO
{
    public class IndividualSetDTO
    {
        public int IndividualSetId { get; set; }
        public int? ExerciseMarkupId { get; set; }
        public double Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
