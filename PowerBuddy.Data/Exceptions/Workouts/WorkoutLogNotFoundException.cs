using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutLogNotFoundException : Exception
    {
        public WorkoutLogNotFoundException() : base("No Workout Log Found with the supplied parameters")
        {

        }
    }
}
