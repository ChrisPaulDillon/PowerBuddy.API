using System.Threading.Tasks;
using PowerLifting.Data.Entities.Account;

namespace PowerLifting.LiftingStats.Contracts
{
    public interface ILiftingStatAuditRepository
    {
        /// <summary>
        /// Creates a new lifting stat audit for a specific user with a specific rep range
        /// </summary>
        Task<int> CreateLiftingStatAudit(LiftingStatAudit liftingStatAudit);
    }
}