using Powerlifting.Common;
using PowerLifting.LiftingStats.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.LiftingStats.Repository
{
    public class LiftingStatAuditRepository : RepositoryBase<LiftingStatAudit>, ILiftingStatAuditRepository
    {
        public LiftingStatAuditRepository(PowerliftingContext context) : base(context)
        {
        }

        public void CreateLiftingStatAudit(LiftingStatAudit liftingStatAudit)
        {
            Create(liftingStatAudit);
        }
    }
}
