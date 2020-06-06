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

        public async Task<ProgramLogRepSchemeDTO> GetProgramLogRepScheme(int programLogRepSchemeId)
        {
            return await PowerliftingContext.Set<ProgramLogRepScheme>()
                .AsNoTracking()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .ProjectTo<ProgramLogRepSchemeDTO>(_mapper.ConfigurationProvider)
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

        public async Task<bool> DoesRepSchemeExist(int programLogRepSchemeId)
        {
            return await PowerliftingContext.Set<ProgramLogRepScheme>()
                .AsNoTracking()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .AnyAsync();
        }
    }
}
