using System.Threading.Tasks;
using PowerLifting.Service.ProgramLogs.Model;

namespace PowerLifting.Service.ProgramLogs.Contracts.Repositories
{
    public interface IProgramLogRepSchemeRepository : IRepositoryBase<ProgramLogRepScheme>
    {
        /// <summary>
        ///     Allows the user to add another set / rep onto a given exercise
        /// </summary>
        /// <param name="programLogRepScheme"></param>
        /// <returns></returns>
        Task CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme);
    }
}