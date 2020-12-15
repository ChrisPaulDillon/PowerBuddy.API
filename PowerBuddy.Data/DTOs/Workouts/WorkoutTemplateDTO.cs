﻿using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutTemplateDTO
    {
        public int WorkoutTemplateId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<WorkoutExerciseDTO> WorkoutExercises { get; set; }
        public string UserId { get; set; }
    }
}