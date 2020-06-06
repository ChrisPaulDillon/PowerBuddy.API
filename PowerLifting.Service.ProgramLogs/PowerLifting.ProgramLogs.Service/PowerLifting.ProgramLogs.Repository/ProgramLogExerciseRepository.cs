using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerLifting.ProgramLogs.Contracts.Repositories;
using AutoMapper;
using PowerLifting.Entity.ProgramLogs.DTO;
using AutoMapper.QueryableExtensions;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseRepository : RepositoryBase<ProgramLogExercise>, IProgramLogExerciseRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogExerciseRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProgramLogExerciseDTO>> GetProgramExercisesByProgramLogDayId(int programLogDayId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogDayId == programLogDayId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProgramLogExerciseDTO> GetProgramLogExerciseById(int programLogExerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogExerciseId == programLogExerciseId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DoesExerciseExist(int programLogExerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExercise>()
                .AsNoTracking()
                .Where(x => x.ProgramLogExerciseId == programLogExerciseId)
                .ProjectTo<ProgramLogExerciseDTO>(_mapper.ConfigurationProvider)
                .AnyAsync();
        }

        public void CreateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Create(programLogExercise);
        }

        public void DeleteProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Delete(programLogExercise);
        }

        public void UpdateProgramLogExercise(ProgramLogExercise programLogExercise)
        {
            Update(programLogExercise);
        }
    }
}
