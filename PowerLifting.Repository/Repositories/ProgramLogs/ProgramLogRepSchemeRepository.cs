using Powerlifting.Repository;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using PowerLifting.Persistence;
using PowerLifting.Service.ProgramLogRepSchemes;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogRepSchemeRepository : RepositoryBase<ProgramLogRepScheme>, IProgramLogRepSchemeRepository
    {
        public ProgramLogRepSchemeRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
