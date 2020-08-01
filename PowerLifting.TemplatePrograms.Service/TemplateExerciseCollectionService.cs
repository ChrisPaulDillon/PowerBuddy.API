using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    }
}