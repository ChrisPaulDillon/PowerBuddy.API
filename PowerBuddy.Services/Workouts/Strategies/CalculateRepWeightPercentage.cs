namespace PowerBuddy.Services.Workouts.Strategies
{
    public class CalculateRepWeightPercentage : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal percentage)
        {
            var percent = percentage / 100;
            return weightInput * percent;
        }
    }
}
