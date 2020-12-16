using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutDayNotFoundException : Exception
    {
        public WorkoutDayNotFoundException() : base("No Workout Found with the supplied parameters")
        {
            
        }
    }
}
