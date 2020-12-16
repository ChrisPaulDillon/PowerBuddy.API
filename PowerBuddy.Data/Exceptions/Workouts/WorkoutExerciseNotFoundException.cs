using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutExerciseNotFoundException : Exception
    {
        public WorkoutExerciseNotFoundException() : base("No Workout Exercise Found with the supplied parameters")
        {

        }
    }
}
