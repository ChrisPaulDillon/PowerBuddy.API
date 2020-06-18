using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogRepSchemeRepository : RepositoryBase<ProgramLogRepScheme>, IProgramLogRepSchemeRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogRepSchemeRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ProgramLogRepScheme> GetProgramLogRepSchemeById(int programLogRepSchemeId)
        {
            return await PowerliftingContext.Set<ProgramLogRepScheme>()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            await Create(programLogRepScheme);
        }

        public async Task<bool> UpdateProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            return await Update(programLogRepScheme);
        }

        public async Task<bool> DeleteProgramLogRepScheme(ProgramLogRepScheme programLogRepScheme)
        {
            return await Delete(programLogRepScheme);
        }

        public async Task<bool> DoesRepSchemeExist(int programLogRepSchemeId)
        {
            return await PowerliftingContext.Set<ProgramLogRepScheme>()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .AsNoTracking()
                .AnyAsync();
        }
    }
}
