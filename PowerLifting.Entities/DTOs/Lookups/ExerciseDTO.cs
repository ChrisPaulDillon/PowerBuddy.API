using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerLifting.Entities.DTOs.Lookups
{
    /// <summary>
    /// Used for a lookups table for each individual lift
    /// </summary>
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public String ExerciseName { get; set; }
        public int? ExerciseCategoryId { get; set; }
        public virtual ExerciseCategoryDTO ExerciseCategory { get; set; }
    }
}
