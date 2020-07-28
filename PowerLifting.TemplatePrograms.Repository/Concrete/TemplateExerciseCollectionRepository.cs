using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PowerLifting.Data.Entities.Templates;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Repository.Contracts;

namespace PowerLifting.TemplatePrograms.Repository.Concrete
{
    public class TemplateExerciseCollectionRepository : ITemplateExerciseCollectionRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateExerciseCollectionRepository(PowerLiftingContext context, IMapper mapper)
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
