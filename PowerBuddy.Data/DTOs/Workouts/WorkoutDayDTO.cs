using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.DTOs.Workouts
{
    public class WorkoutDayDTO
    {
        public int WorkoutDayId { get; set; }
        public int? WorkoutLogId { get; set; }
        public int? WeekNo { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }
        public virtual IEnumerable<WorkoutExerciseDTO> WorkoutExercises { get; set; }
        public string TemplateName { get; set; }
    }
}
