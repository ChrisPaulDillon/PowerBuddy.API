using PowerLifting.Persistence;
using PowerLifting.Repository.Exercises;
using PowerLifting.Repository.LiftingStats;
using PowerLifting.Repository.ProgramLogs;
using PowerLifting.Repository.Templates;
using PowerLifting.Repository.Users;
using PowerLifting.Repository.UserSettings;
using PowerLifting.Service;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogs.Contracts.Repositories;
using PowerLifting.Service.SystemServices.RepSchemeTypes;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.TemplatePrograms.Contracts;
using PowerLifting.Service.TemplatePrograms.Contracts.Repositories;
using PowerLifting.Service.Users;
using PowerLifting.Service.UserSettings;

namespace PowerLifting.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ILiftingStatRepository _liftingStatRepo;
        private ILiftingStatAuditRepository _liftingStatAuditRepo;
        private IExerciseRepository _exerciseRepo;
        private IExerciseTypeRepository _exerciseTypeRepo;
        private IExerciseMuscleGroupRepository _exerciseMuscleGroupRepo;
        private ITemplateDifficultyRepository _templateDifficultyRepo;
        private IRepSchemeTypeRepository _repSchemeTypeRepo;
        private IProgramLogRepository _programLogRepo;
        private IProgramLogWeekRepository _programLogWeekRepo;
        private IProgramLogDayRepository _programLogDayRepo;
        private IProgramLogExerciseRepository _programLogExerciseRepo;
        private IProgramLogRepSchemeRepository _programLogRepSchemeRepo;
        private ITemplateProgramRepository _templateProgramRepo;
        private ITemplateWeekRepository _templateWeekRepo;
        private ITemplateDayRepository _templateDayRepo;
        private ITemplateExerciseRepository _templateExerciseRepo;
        private ITemplateRepSchemeRepository _templateRepSchemeRepo;
        private ITemplateExerciseCollectionRepository _templateExerciseCollectionRepo;
        private IUserRepository _userRepo;
        private IUserSettingRepository _userSettingRepo;

        private PowerliftingContext _context;

        public RepositoryWrapper(PowerliftingContext repositoryContext)
        {
            _context = repositoryContext;
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

        public IExerciseTypeRepository ExerciseType
        {
            get
            {
                if (_exerciseTypeRepo == null)
                {
                    _exerciseTypeRepo = new ExerciseTypeRepository(_context);
                }

                return _exerciseTypeRepo;
            }
        }

        public IExerciseMuscleGroupRepository ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroupRepo == null)
                {
                    _exerciseMuscleGroupRepo = new ExerciseMuscleGroupRepository(_context);
                }

                return _exerciseMuscleGroupRepo;
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

        public IProgramLogWeekRepository ProgramLogWeek
        {
            get
            {
                if (_programLogWeekRepo == null)
                {
                    _programLogWeekRepo = new ProgramLogWeekRepository(_context);
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
                    _programLogDayRepo = new ProgramLogDayRepository(_context);
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

        public IUserSettingRepository UserSetting
        {
            get
            {
                if (_userSettingRepo == null)
                {
                    _userSettingRepo = new UserSettingRepository(_context);
                }

                return _userSettingRepo;
            }
        }
    }
}