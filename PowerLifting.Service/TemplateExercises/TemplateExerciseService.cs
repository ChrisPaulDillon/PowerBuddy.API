using AutoMapper;
using PowerLifting.Service.ServiceWrappers;

namespace PowerLifting.Service.TemplateExercises
{
    public class TemplateExerciseService : ITemplateExerciseService
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repo;

        public TemplateExerciseService(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
