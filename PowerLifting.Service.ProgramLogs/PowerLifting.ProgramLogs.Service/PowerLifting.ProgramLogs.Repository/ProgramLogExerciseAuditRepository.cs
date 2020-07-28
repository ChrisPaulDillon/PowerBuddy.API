using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Persistence;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseAuditRepository : IProgramLogExerciseAuditRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogExerciseAuditRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId)
        {
            return await _context.Set<ProgramLogExerciseAudit>().AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.SelectedCount).Take(3)
                .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAudit(string userId, int exerciseId)
        {
            return await _context.Set<ProgramLogExerciseAudit>()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateProgramLogExerciseAudit(ProgramLogExerciseAudit audit)
        {
            _context.Add(audit);
            await _context.SaveChangesAsync();
            return audit.ProgramLogExerciseAuditId;
        }
    }
}
