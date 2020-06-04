using PowerLifting.LiftingStats.Contracts;

namespace PowerLifting.LiftingStats.Service
{
    public interface ILiftingStatsWrapper
    {
        ILiftingStatRepository LiftingStat { get; }
        ILiftingStatAuditRepository LiftingStatAudit { get; }
    }
}