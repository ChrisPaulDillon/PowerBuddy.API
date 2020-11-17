namespace PowerBuddy.Services.ProgramLogs.Strategies
{
    public class CalculateRepWeightIncremental : ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal baseIncrementalJump)
        {
            return weightInput + baseIncrementalJump;
        }
    }
}
