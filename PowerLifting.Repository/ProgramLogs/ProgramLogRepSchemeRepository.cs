using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ProgramLogRepScheme> GetProgramLogRepScheme(int programLogRepSchemeId)
        {
            return await PowerliftingContext.Set<ProgramLogRepScheme>().Where(x => x.ProgramLogRepSchemeId
                                                                                == programLogRepSchemeId)
                                                                                .FirstOrDefaultAsync();
        }

        public void CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            Create(programLogRepScheme);
        }

        public void UpdateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            Update(programLogRepScheme);
        }

        public void DeleteProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            Delete(programLogRepScheme);
        }
    }
}
