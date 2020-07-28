using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateExerciseCollectionRepository : ITemplateExerciseCollectionRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public TemplateExerciseCollectionRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<int> GetTemplateExerciseCollectionByTemplateId(int templateId)
        {
            return _context.Set<TemplateExerciseCollection>().Where(x => x.TemplateProgramId == templateId)
                                                                              .Select(x => x.ExerciseId)
                                                                              .ToList();

        }
    }
}
