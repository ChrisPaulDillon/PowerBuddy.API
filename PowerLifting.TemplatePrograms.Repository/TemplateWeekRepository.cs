using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Contracts.Repositories;

namespace PowerLifting.TemplatePrograms.Repository
{
    public class TemplateWeekRepository : ITemplateWeekRepository
    {
        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public TemplateWeekRepository(PowerliftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
