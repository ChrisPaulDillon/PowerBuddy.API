﻿using System.Collections.Generic;
using PowerBuddy.Data.Entities;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutExerciseDTO
    {
        public int WorkoutExerciseId { get; set; }
        public int WorkoutDayId { get; set; }
        public int ExerciseId { get; set; }
        public string Comment { get; set; }
        public string ExerciseName { get; set; }
        public int WorkoutExerciseTonnageId { get; set; }
        public decimal ExerciseTonnage { get; set; }
        public int NoOfSets { get; set; }
        public virtual IEnumerable<WorkoutSetDTO> WorkoutSets { get; set; }
        public WorkoutExerciseTonnage WorkoutExerciseTonnage { get; set; }
    }
}
