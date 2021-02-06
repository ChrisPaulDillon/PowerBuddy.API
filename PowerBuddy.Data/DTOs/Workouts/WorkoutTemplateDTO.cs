using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Workouts
{
    public class WorkoutTemplateDto
    {
        public int WorkoutTemplateId { get; set; }
        public string WorkoutName { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<WorkoutExerciseDto> WorkoutExercises { get; set; }
        public string UserId { get; set; }
    }
}
