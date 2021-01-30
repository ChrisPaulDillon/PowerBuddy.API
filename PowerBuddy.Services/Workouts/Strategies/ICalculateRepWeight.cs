namespace PowerBuddy.Services.Workouts.Strategies
{
    public interface ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal percentage);
    }
}
