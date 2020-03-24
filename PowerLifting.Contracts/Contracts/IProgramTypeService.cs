using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.Entities.Model;
using PowerLifting.Entities.Model.Lookups;
using PowerLifting.Entities.Model.Programs;

namespace Powerlifting.Contracts.Contracts
{
    public interface IProgramTypeService : IServiceBase<ProgramType>
    {
        Task<List<ProgramType>> GetAllIncludeProgramExercises();
        Task<ProgramType> CreateProgramType(ProgramType programType);
        Task<ProgramType> GetProgramTypeByName(string programType);
    }
}
