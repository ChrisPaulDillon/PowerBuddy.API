namespace PowerBuddy.Data.Models.Workouts
{
    public readonly struct WorkoutLogExistsOnDate
    {
        public string Message { get; }

        public WorkoutLogExistsOnDate(string message)
        {
            Message = message;
        }
    }
}
