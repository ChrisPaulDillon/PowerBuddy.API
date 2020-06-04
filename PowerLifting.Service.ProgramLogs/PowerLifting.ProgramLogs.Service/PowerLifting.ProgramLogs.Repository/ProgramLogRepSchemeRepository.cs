using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
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
