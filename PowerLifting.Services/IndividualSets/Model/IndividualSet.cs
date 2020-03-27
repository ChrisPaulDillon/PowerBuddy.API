using System;

namespace Powerlifting.Services.IndividualSets.Model
{
    public class IndividualSet
    {
        public int IndividualSetId { get; set; }
        public int? ExerciseMarkupId { get; set; }
        public int? ProgramExerciseId { get; set; } //Is this set for a fixed program or a user?
        public double? Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
