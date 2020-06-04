using System.Collections.Generic;
using AutoMapper;
using PowerLifting.TemplatePrograms.Contracts;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateExerciseCollectionService : ITemplateExerciseCollectionService
    {
        private readonly IMapper _mapper;
        private readonly ITemplateProgramWrapper _repo;

        public TemplateExerciseCollectionService(ITemplateProgramWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<int> GetTemplateExerciseCollectionByTemplateProgramId(int templateProgramId)
        {
            var tec = _repo.TemplateExerciseCollection.GetTemplateExerciseCollectionByTemplateId(templateProgramId);
            return tec;
        }
    }
}