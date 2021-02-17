using System;
using System.Collections.Generic;

namespace PowerBuddy.Data.Dtos.Workouts
{
    public class WorkoutDayDto
    {
        public int WorkoutDayId { get; set; }
        public int? WorkoutLogId { get; set; }
        public int? WeekNo { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool Completed { get; set; }
        public virtual IEnumerable<WorkoutExerciseDto> WorkoutExercises { get; set; }
        public string TemplateName { get; set; }
        public bool UsingMetric { get; set; }
    }
}
