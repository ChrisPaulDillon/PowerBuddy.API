using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Contracts.Contracts;
using PowerLifting.Persistence;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;
using System.Collections.Generic;

namespace Powerlifting.Services.Service
{
    public class ProgramTypeService : ServiceBase<ProgramType>, IProgramTypeService
    {
        public ProgramTypeService(PowerliftingContext ServiceContext)
            : base(ServiceContext)
        {
        }

        public Task<ProgramType> CreateProgramType(ProgramType programType)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProgramType>> GetAllIncludeProgramExercises()
        {
            return await PowerliftingContext.Set<ProgramType>().Include(x => x.ProgramExercises).ThenInclude(s => s.IndividualSets).ToListAsync();
        }

        public async Task<ProgramType> GetProgramTypeByName(string programName)
        {
            return await PowerliftingContext.Set<ProgramType>().Where(x => x.Name == programName).FirstOrDefaultAsync();
        }
    }
}
