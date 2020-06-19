using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Entity.ProgramLogs.DTO;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogRepSchemeRepository : IProgramLogRepSchemeRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogRepSchemeRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogRepScheme> GetProgramLogRepSchemeById(int programLogRepSchemeId)
        {
            return await _context.Set<ProgramLogRepScheme>()
                                 .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                                 .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogRepScheme> CreateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _context.Add(programLogRepScheme);

            await _context.SaveChangesAsync();
            return programLogRepScheme;
        }

        public async Task<bool> UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _context.Update(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _context.Remove(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DoesRepSchemeExist(int programLogRepSchemeId)
        {
            return await _context.Set<ProgramLogRepScheme>()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .AsNoTracking()
                .AnyAsync();
        }

        public async Task<bool> MarkProgramLogRepSchemeComplete(ProgramLogRepScheme programLogRepScheme)
        {
            _context.Update(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
