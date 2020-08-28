using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PowerLifting.Data.Entities.Exercises
{
    /// <summary>
    /// Represents all exercise muscle groups that can be worked
    /// </summary>
    public class ExerciseMuscleGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExerciseMuscleGroupId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public string Region { get; set; }
    }
}
