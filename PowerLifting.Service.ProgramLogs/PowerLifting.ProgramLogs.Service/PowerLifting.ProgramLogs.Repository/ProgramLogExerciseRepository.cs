using Microsoft.EntityFrameworkCore;
using PowerLifting.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.Entities.ProgramLogs;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseRepository : IProgramLogExerciseRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogExerciseRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId)
        {
            return await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogDayId == programLogDayId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProgramLogExercise> GetProgramLogExerciseById(int programLogExerciseId)
        {
            return await _context.Set<ProgramLogExercise>()
                .Where(x => x.ProgramLogExerciseId == programLogExerciseId)
                .Include(x => x.ProgramLogRepSchemes)
                .Include(x => x.Exercise)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DoesExerciseExist(int programLogExerciseId)
        {
            return await _context.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogExerciseId == programLogExerciseId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .AnyAsync();
        }

        public async Task<ProgramLogExercise> CreateProgramLogExercise(CProgramLogExerciseDTO programLogExercise)
        {
            var exerciseEntity = _mapper.Map<ProgramLogExercise>(programLogExercise);
            _context.Add(exerciseEntity);

            await _context.SaveChangesAsync();
            return exerciseEntity;
        }

        public async Task<bool> UpdateProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO)
        {
            var programLogExercise = _mapper.Map<ProgramLogExercise>(programLogExerciseDTO);
            _context.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> DeleteProgramLogExercise(ProgramLogExerciseDTO programLogExerciseDTO)
        {
            var programLogExercise = _mapper.Map<ProgramLogExercise>(programLogExerciseDTO);
            _context.Remove(programLogExercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<bool> MarkProgramLogExerciseComplete(ProgramLogExercise programLogExercise)
        {
            _context.Update(programLogExercise);

            var changedRows = await _context.SaveChangesAsync();
            return changedRows > 0;
        }

        public async Task<int> DoesExerciseExistForDay(int programLogDayId, int exerciseId)
        {
            var result = await _context.Set<ProgramLogExercise>()
                .Where(x => x.ProgramLogDayId == programLogDayId && x.ExerciseId == exerciseId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result != null ? result.ProgramLogExerciseId : 0;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
