using System.Threading.Tasks;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.Repository.LiftingStats
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
