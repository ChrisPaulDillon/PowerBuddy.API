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

        private PowerliftingContext _context;

        public TemplateProgramWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public ITemplateProgramRepository TemplateProgram
        {
            get
            {
                if (_templateProgramRepo == null)
                {
                    _templateProgramRepo = new TemplateProgramRepository(_context);
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
                    _templateWeekRepo = new TemplateWeekRepository(_context);
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
                    _templateDayRepo = new TemplateDayRepository(_context);
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
                    _templateExerciseRepo = new TemplateExerciseRepository(_context);
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
                    _templateRepSchemeRepo = new TemplateRepSchemeRepository(_context);
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
                    _templateExerciseCollectionRepo = new TemplateExerciseCollectionRepository(_context);
                }

                return _templateExerciseCollectionRepo;
            }
        }
    }
}
