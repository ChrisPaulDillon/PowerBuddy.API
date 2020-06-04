﻿namespace PowerLifting.Entity.System.ExerciseMuscleGroups.Models
{ 
    /// <summary>
    /// Represents a muscle group to be trained such as neck, shoulders etc.
    /// </summary>
    public class ExerciseMuscleGroup
    {
        public int ExerciseMuscleGroupId { get; set; }
        public string ExerciseMuscleGroupName { get; set; }
        public int ExerciseId { get; set; }
    }
}