using System;
using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.Repository.Repositories
{
    public class LiftingStatAuditRepository : RepositoryBase<LiftingStatAudit>, ILiftingStatAuditRepository
    {
        public LiftingStatAuditRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
