using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Persistence;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateExerciseCollectionService : ITemplateExerciseCollectionService
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateExerciseCollectionService(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId)
        {
            return _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == templateProgramId)
                .Select(x => x.ExerciseId)
                .ToList();
        }

        public async Task<IEnumerable<LiftingStat>> DoesUserHaveExerciseCollection1RMSet(int templateProgramId, string userId)
        {
            var tec = _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == templateProgramId)
                .AsNoTracking()
                .Select(x => x.ExerciseId)
                .ToList();

            var liftingStats = await _context.LiftingStat.Where(x => x.UserId == userId && x.RepRange == 1).AsNoTracking().ToListAsync();

            var liftingStatsToCreate = liftingStats.Where(item1 => tec.All(item2 => item1.ExerciseId != item2));

            return liftingStatsToCreate;
        }
    }
}