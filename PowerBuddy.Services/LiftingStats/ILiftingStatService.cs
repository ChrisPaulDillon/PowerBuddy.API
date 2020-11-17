namespace PowerBuddy.Services.LiftingStats
{
    public interface ILiftingStatService
    {
        void CreateLiftingStatAudit(int liftingStatId, int exerciseId, int repRange, decimal weight, string userId);
    }
}
