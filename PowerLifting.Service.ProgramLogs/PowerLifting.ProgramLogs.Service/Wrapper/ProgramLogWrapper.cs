using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Repository;

namespace PowerLifting.ProgramLogs.Service.Wrapper
{
    public class ProgramLogWrapper : IProgramLogWrapper
    {
        private IProgramLogRepository _programLogRepo;
        private IProgramLogWeekRepository _programLogWeekRepo;
        private IProgramLogDayRepository _programLogDayRepo;
        private IProgramLogExerciseRepository _programLogExerciseRepo;
        private IProgramLogExerciseAuditRepository _programLogExerciseAuditRepo;
        private IProgramLogRepSchemeRepository _programLogRepSchemeRepo;

        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public ProgramLogWrapper(PowerLiftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public IProgramLogRepository ProgramLog
        {
            get
            {
                if (_programLogRepo == null)
                {
                    _programLogRepo = new ProgramLogRepository(_context, _mapper);
                }

                return _programLogRepo;
            }
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

        public IProgramLogDayRepository ProgramLogDay
        {
            get
            {
                if (_programLogDayRepo == null)
                {
                    _programLogDayRepo = new ProgramLogDayRepository(_context, _mapper);
                }

                return _programLogDayRepo;
            }
        }

        public IProgramLogExerciseRepository ProgramLogExercise
        {
            get
            {
                if (_programLogExerciseRepo == null)
                {
                    _programLogExerciseRepo = new ProgramLogExerciseRepository(_context, _mapper);
                }

                return _programLogExerciseRepo;
            }
        }

        public IProgramLogExerciseAuditRepository ProgramLogExerciseAudit
        {
            get
            {
                if (_programLogExerciseAuditRepo == null)
                {
                    _programLogExerciseAuditRepo = new ProgramLogExerciseAuditRepository(_context, _mapper);
                }

                return _programLogExerciseAuditRepo;
            }
        }

        public IProgramLogRepSchemeRepository ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepSchemeRepo == null)
                {
                    _programLogRepSchemeRepo = new ProgramLogRepSchemeRepository(_context, _mapper);
                }

                return _programLogRepSchemeRepo;
            }
        }
    }
}
