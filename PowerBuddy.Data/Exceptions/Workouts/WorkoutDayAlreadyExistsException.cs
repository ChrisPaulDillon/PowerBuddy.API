using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutDayAlreadyExistsException : Exception
    {
        public WorkoutDayAlreadyExistsException() : base("Workout Day Already exists for the given user")
        {

        }
    }
}
