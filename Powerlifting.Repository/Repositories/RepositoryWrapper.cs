using PowerLifting.Persistence;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ServiceWrappers;
using PowerLifting.Service.Users;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Services.Exercises;
using PowerLifting.Services.LiftingStats;
using PowerLifting.Services.ProgramLogExercises;
using PowerLifting.Services.ProgramLogRepSchemes;
using PowerLifting.Services.ProgramLogs;
using PowerLifting.Services.TemplateExercises;
using PowerLifting.Services.TemplatePrograms;
using PowerLifting.Services.TemplateRepSchemes;
using PowerLifting.Services.Users;

namespace PowerLifting.Repository.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository _userRepo;
        private ILiftingStatRepository _liftingStatRepo;
        private ILiftingStatAuditRepository _liftingStatAuditRepo;
        private IExerciseRepository _exerciseRepo;
        private IExerciseCategoryRepository _exerciseCategoryRepo;
        private IProgramLogRepository _programLogRepo;
        private IProgramLogExerciseRepository _programLogExerciseRepo;
        private IProgramLogRepSchemeRepository _programLogRepSchemeRepo;
        private ITemplateProgramRepository _templateProgramRepo;
        private ITemplateExerciseRepository _templateExerciseRepo;
        private ITemplateRepSchemeRepository _templateRepSchemeRepo;

        private PowerliftingContext _context;

        public RepositoryWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_context);
                }

                return _userRepo;
            }
        }

        public ILiftingStatRepository LiftingStat
        {
            get
            {
                if (_liftingStatRepo == null)
                {
                    _liftingStatRepo = new LiftingStatRepository(_context);
                }

                return _liftingStatRepo;
            }
        }

        public ILiftingStatAuditRepository LiftingStatAudit
        {
            get
            {
                if (_liftingStatAuditRepo == null)
                {
                    _liftingStatAuditRepo = new LiftingStatAuditRepository(_context);
                }

                return _liftingStatAuditRepo;
            }
        }

        public IExerciseRepository Exercise
        {
            get
            {
                if (_exerciseRepo == null)
                {
                    _exerciseRepo = new ExerciseRepository(_context);
                }

                return _exerciseRepo;
            }
        }

        public IExerciseCategoryRepository ExerciseCategory
        {
            get
            {
                if (_exerciseCategoryRepo == null)
                {
                    _exerciseCategoryRepo = new ExerciseCategoryRepository(_context);
                }

                return _exerciseCategoryRepo;
            }
        }


        public IProgramLogRepository ProgramLog
        {
            get
            {
                if (_programLogRepo == null)
                {
                    _programLogRepo = new ProgramLogRepository(_context);
                }

                return _programLogRepo;
            }
        }

        public IProgramLogExerciseRepository ProgramLogExercise
        {
            get
            {
                if (_programLogExerciseRepo == null)
                {
                    _programLogExerciseRepo = new ProgramLogExerciseRepository(_context);
                }

                return _programLogExerciseRepo;
            }
        }

        public IProgramLogRepSchemeRepository ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepSchemeRepo == null)
                {
                    _programLogRepSchemeRepo = new ProgramLogRepSchemeRepository(_context);
                }

                return _programLogRepSchemeRepo;
            }
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
    }
}