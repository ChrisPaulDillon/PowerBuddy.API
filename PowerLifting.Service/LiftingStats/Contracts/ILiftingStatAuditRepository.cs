using System.Threading.Tasks;
using PowerLifting.Service.LiftingStatsAudit.Model;

namespace PowerLifting.Service.LiftingStatsAudit
{
    public interface ILiftingStatAuditRepository
    {  
        /// <summary>
        /// Creates a new lifting stat audit for a specific user with a specific rep range
        /// </summary>
        /// <param name="liftingStatAudit"></param>
        void CreateLiftingStatAudit(LiftingStatAudit liftingStatAudit);
    }
}