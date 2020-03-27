using Powerlifting.Repository;
using Powerlifting.Services.ProgramLogSets.Model;
using PowerLifting.Persistence;
using PowerLifting.Services.ProgramLogSets;

namespace PowerLifting.Repository.Repositories
{
    public class ProgramLogSetRepository : RepositoryBase<ProgramLogSet>, IProgramLogSetRepository
    {
        public ProgramLogSetRepository(PowerliftingContext context) : base(context)
        {
        }
    }
}
