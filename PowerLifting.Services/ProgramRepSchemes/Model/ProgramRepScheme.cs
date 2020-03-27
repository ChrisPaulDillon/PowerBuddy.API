using System;
namespace PowerLifting.Services.ProgramRepSchemes.Model
{
    public class ProgramRepScheme
    {
        public int ProgramRepSchemeId { get; set; }
        public int ProgramExerciseId { get; set; } //Is this set for a fixed program or a user?
        public double Percentage { get; set; }
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public double WeightLifted { get; set; }
    }
}
