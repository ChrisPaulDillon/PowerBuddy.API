using System.Linq;
using HotChocolate;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Users;
using PowerLifting.Service.Account;

namespace PowerLifting.API.GraphQL.Resolvers
{
    public class AccountResolvers
    {

        //[UsePaging]
        //[UseSorting]
        //[UseSelection]
        public IQueryable<ProgramLogDTO> GetProgramLogs([Parent] UserDTO account, [Service] IAccountService svc)
        {
            return svc.GetProgramLogsQueryable(account.UserId);
        }

        public IQueryable<LiftingStatDTO> GetLiftingStats([Parent] UserDTO account, [Service] IAccountService svc)
        {
            return svc.GetLiftingStatsQueryable(account.UserId);
        }
    }
}
