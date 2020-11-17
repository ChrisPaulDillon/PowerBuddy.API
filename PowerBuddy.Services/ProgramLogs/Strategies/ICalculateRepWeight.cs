namespace PowerBuddy.Services.ProgramLogs.Strategies
{
    public interface ICalculateRepWeight
    {
        public decimal CalculateWeight(decimal weightInput, decimal percentage);
    }
}
