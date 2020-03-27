using PowerLifting.Persistence;
using PowerLifting.Repositorys.RepositoryWrappers;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Services.Exercises;
using PowerLifting.Services.LiftingStats;
using PowerLifting.Services.ProgramLogs;
using PowerLifting.Services.TemplatePrograms;
using PowerLifting.Services.Users;

namespace PowerLifting.Repository.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository _userRepo;
        private ILiftingStatRepository _liftingStatRepo;
        private IExerciseRepository _exerciseRepo;
        private IExerciseCategoryRepository _exerciseCategoryRepo;
        private IProgramLogRepository _programLogRepo;
        private ITemplateProgramRepository _programTemplateRepo;

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

        public ITemplateProgramRepository TemplateProgram
        {
            get
            {
                if (_programTemplateRepo == null)
                {
                    _programTemplateRepo = new TemplateProgramRepository(_context);
                }

                return _programTemplateRepo;
            }
        }
    }
}