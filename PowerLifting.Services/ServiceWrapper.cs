using PowerLifting.Persistence;
using Powerlifting.Services.Service;
using Powerlifting.Contracts;
using Powerlifting.Contracts.Contracts;

namespace Powerlifting.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private PowerliftingContext _repoContext;
        private IUserService _user;
        private ILiftingStatService _liftingStats;
        private IExerciseService _exercise;
        private IExerciseCategoryService _exerciseCategory;
        private IProgramLogService _programLogs;
        private IProgramTypeService _programType;

        public ServiceWrapper(PowerliftingContext ServiceContext)
        {
            _repoContext = ServiceContext;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoContext);
                }

                return _user;
            }
        }

        public ILiftingStatService LiftingStat
        {
            get
            {
                if (_liftingStats == null)
                {
                    _liftingStats = new LiftingStatService(_repoContext);
                }

                return _liftingStats;
            }
        }

        public IExerciseService Exercise
        {
            get
            {
                if (_exercise == null)
                {
                    _exercise = new ExerciseService(_repoContext);
                }

                return _exercise;
            }
        }

        public IExerciseCategoryService ExerciseCategory
        {
            get
            {
                if (_exerciseCategory == null)
                {
                    _exerciseCategory = new ExerciseCategoryService(_repoContext);
                }

                return _exerciseCategory;
            }
        }


        public IProgramLogService ProgramLog
        {
            get
            {
                if (_programLogs == null)
                {
                    _programLogs = new ProgramLogService(_repoContext);
                }

                return _programLogs;
            }
        }

        public IProgramTypeService ProgramType
        {
            get
            {
                if (_programType == null)
                {
                    _programType = new ProgramTypeService(_repoContext);
                }

                return _programType;
            }
        }


        public void Save()
        {
            _repoContext.SaveChangesAsync();
        }
    }
}