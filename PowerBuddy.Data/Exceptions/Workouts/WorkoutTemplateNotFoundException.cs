using System;

namespace PowerBuddy.Data.Exceptions.Workouts
{
    public class WorkoutTemplateNotFoundException : Exception
    {
        public WorkoutTemplateNotFoundException() : base("No Workout Template found with the associated parameters")
        {

        }
    }
}
