using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Powerlifting.Common;
using PowerLifting.Entity.ProgramLogs.Model;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Contracts.Repositories;

namespace PowerLifting.ProgramLogs.Repository
{
    public class ProgramLogExerciseAuditRepository : RepositoryBase<ProgramLogExerciseAudit>, IProgramLogExerciseAuditRepository
    {
        private readonly IMapper _mapper;

        public ProgramLogExerciseAuditRepository(PowerliftingContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAuditCount(string userId)
        {
            return await PowerliftingContext.Set<ProgramLogExerciseAudit>().AsNoTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.SelectedCount).Take(3)
                .FirstOrDefaultAsync();
        }

        public async Task<ProgramLogExerciseAudit> GetProgramLogExerciseAudit(string userId, int exerciseId)
        {
            return await PowerliftingContext.Set<ProgramLogExerciseAudit>()
                .Where(x => x.UserId == userId && x.ExerciseId == exerciseId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateProgramLogExerciseAudit(ProgramLogExerciseAudit audit)
        {
            await Create(audit);
        }

        public async Task<bool> UpdateProgramLogExerciseAudit(ProgramLogExerciseAudit audit)
        {
            return await Update(audit);
        }
    }
}
