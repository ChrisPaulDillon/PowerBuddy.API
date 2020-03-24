using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.DTOs
{
    public class IndividualSetDTO
    {
        public int IndividualSetId { get; set; }
        public int? ExerciseMarkupId { get; set; }
        public int? ProgramExerciseId { get; set; } //Is this set for a fixed program or a user?
        public int SetNo { get; set; }
        public int NumOfReps { get; set; }
        public Double WeightLifted { get; set; }
    }
}
