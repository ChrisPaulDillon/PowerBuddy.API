using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Repository.Contracts;

namespace PowerLifting.TemplatePrograms.Repository.Concrete
{
    public class TemplateDayRepository : ITemplateDayRepository
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public TemplateDayRepository(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
