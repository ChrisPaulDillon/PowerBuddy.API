using AutoMapper;
using PowerLifting.Persistence;
using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Repositories;
using PowerLifting.TemplatePrograms.Repository;

namespace PowerLifting.TemplatePrograms.Service
{
    public class TemplateProgramWrapper : ITemplateProgramWrapper
    {
        private ITemplateProgramRepository _templateProgramRepo;
        private ITemplateWeekRepository _templateWeekRepo;
        private ITemplateDayRepository _templateDayRepo;
        private ITemplateExerciseRepository _templateExerciseRepo;
        private ITemplateRepSchemeRepository _templateRepSchemeRepo;
        private ITemplateExerciseCollectionRepository _templateExerciseCollectionRepo;

        private readonly PowerliftingContext _context;
        private readonly IMapper _mapper;

        public TemplateProgramWrapper(PowerliftingContext repositoryContext, IMapper mapper)
        {
            _context = repositoryContext;
            _mapper = mapper;
        }

        public ITemplateProgramRepository TemplateProgram
        {
            get
            {
                if (_templateProgramRepo == null)
                {
                    _templateProgramRepo = new TemplateProgramRepository(_context, _mapper);
                }

                return _templateProgramRepo;
            }
        }


        public ITemplateWeekRepository TemplateWeek
        {
            get
            {
                if (_templateWeekRepo == null)
                {
                    _templateWeekRepo = new TemplateWeekRepository(_context, _mapper);
                }

                return _templateWeekRepo;
            }
        }


        public ITemplateDayRepository TemplateDay
        {
            get
            {
                if (_templateDayRepo == null)
                {
                    _templateDayRepo = new TemplateDayRepository(_context, _mapper);
                }

                return _templateDayRepo;
            }
        }

        public ITemplateExerciseRepository TemplateExercise
        {
            get
            {
                if (_templateExerciseRepo == null)
                {
                    _templateExerciseRepo = new TemplateExerciseRepository(_context, _mapper);
                }

                return _templateExerciseRepo;
            }
        }

        public ITemplateRepSchemeRepository TemplateRepScheme
        {
            get
            {
                if (_templateRepSchemeRepo == null)
                {
                    _templateRepSchemeRepo = new TemplateRepSchemeRepository(_context, _mapper);
                }

                return _templateRepSchemeRepo;
            }
        }

        public ITemplateExerciseCollectionRepository TemplateExerciseCollection
        {
            get
            {
                if (_templateExerciseCollectionRepo == null)
                {
                    _templateExerciseCollectionRepo = new TemplateExerciseCollectionRepository(_context, _mapper);
                }

                return _templateExerciseCollectionRepo;
            }
        }
    }
}
