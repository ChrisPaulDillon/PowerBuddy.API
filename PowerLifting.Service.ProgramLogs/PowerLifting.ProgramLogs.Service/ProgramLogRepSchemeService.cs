using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Persistence;

namespace PowerLifting.ProgramLogs.Service
{
    public class ProgramLogRepSchemeService : IProgramLogRepSchemeService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogRepSchemeService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateProgramLogExerciseCollection(IEnumerable<ProgramLogRepSchemeDTO> repSchemeDTOCollection)
        {
            var repSchemeCollection = _mapper.Map<IList<ProgramLogRepScheme>>(repSchemeDTOCollection);
            var programLogExercise = await _context.ProgramLogExercise.FirstOrDefaultAsync(x => x.ProgramLogExerciseId == repSchemeCollection[0].ProgramLogExerciseId);
            programLogExercise.NoOfSets += repSchemeCollection.Count;


            foreach (var repSchemeDTO in repSchemeCollection)
            {
                _context.ProgramLogRepScheme.Add(repSchemeDTO);
            }

            var modifiedRows = await _context.SaveChangesAsync();
            return modifiedRows > 0;
        }

        public async Task<bool> UpdateProgramLogRepScheme(ProgramLogRepSchemeDTO programLogRepSchemeDTO)
        {
            var doesExist = await _context.Set<ProgramLogRepScheme>()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeDTO.ProgramLogRepSchemeId)
                .AsNoTracking()
                .AnyAsync();

            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            var programLogRepScheme = _mapper.Map<ProgramLogRepScheme>(programLogRepSchemeDTO);
            _context.Update(programLogRepScheme);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLogRepScheme(int programLogRepSchemeId)
        {
            var doesExist = await _context.Set<ProgramLogRepScheme>()
                .Where(x => x.ProgramLogRepSchemeId == programLogRepSchemeId)
                .AsNoTracking()
                .AnyAsync();

            if (!doesExist) throw new ProgramLogRepSchemeNotFoundException();

            _context.Remove(new ProgramLogRepScheme() { ProgramLogRepSchemeId = programLogRepSchemeId });

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }
    }
}
