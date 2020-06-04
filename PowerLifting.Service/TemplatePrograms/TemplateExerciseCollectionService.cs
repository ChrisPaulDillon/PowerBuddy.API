using System.Collections.Generic;
using AutoMapper;
using PowerLifting.RepositoryMediator;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;

namespace PowerLifting.Service.TemplatePrograms
{
    public class TemplateExerciseCollectionService : ITemplateExerciseCollectionService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repo;

        public TemplateExerciseCollectionService(IRepositoryWrapper repo, IMapper mapper)
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