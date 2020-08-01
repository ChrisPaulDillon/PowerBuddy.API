using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Repository;

namespace PowerLifting.ProgramLogs.Service.Wrapper
{
    public class ProgramLogWrapper : IProgramLogWrapper
    {
        private IProgramLogWeekRepository _programLogWeekRepo;

        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public IProgramLogWeekRepository ProgramLogWeek
        {
            get
            {
                if (_programLogWeekRepo == null)
                {
                    _programLogWeekRepo = new ProgramLogWeekRepository(_context, _mapper);
                }

                return _programLogWeekRepo;
            }
        }
    }
}
