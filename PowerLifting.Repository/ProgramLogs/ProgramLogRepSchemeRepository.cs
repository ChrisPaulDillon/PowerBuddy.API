using Powerlifting.Repository;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Repository.ProgramLogs
{
    public class ProgramLogRepSchemeRepository : RepositoryBase<ProgramLogRepScheme>, IProgramLogRepSchemeRepository
    {
        public ProgramLogRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
