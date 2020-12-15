using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutSetDTO
    {
        public int WorkoutSetId{ get; set; }
        public int WorkoutExerciseId { get; set; }
        public int SetNo { get; set; }
        public int NoOfReps { get; set; }
        public decimal WeightLifted { get; set; }
        public decimal? Percentage { get; set; }
        public string Comment { get; set; }
        public bool AMRAP { get; set; } //As many reps as possible for this set
        public int? RepsCompleted { get; set; }
        public bool? PersonalBest { get; set; }
        public int? LiftingStatAuditId { get; set; }
    }
}
