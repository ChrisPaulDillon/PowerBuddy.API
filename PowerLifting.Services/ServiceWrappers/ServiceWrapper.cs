using AutoMapper;
using Powerlifting.Services.Users;
using Powerlifting.Service.ExerciseCategories;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramTemplates;
using Powerlifting.Service.Exercises;
using Powerlifting.Service.LiftingStats;
using PowerLifting.Services.Users;
using PowerLifting.Services.LiftingStats;
using PowerLifting.Services.Exercises;
using PowerLifting.Services.ExerciseCategories;
using PowerLifting.Services.ProgramLogs;
using PowerLifting.Services.ProgramTemplates;

namespace Powerlifting.Services.ServiceWrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private IUserRepository _userRepo;

        private ILiftingStatService _liftingStats;
        private ILiftingStatRepository _liftingStatRepo;

        private IExerciseService _exercise;
        private IExerciseRepository _exerciseRepo;

        private IExerciseCategoryService _exerciseCategory;
        private IExerciseCategoryRepository _exerciseCategoryRepo;

        private IProgramLogService _programLogs;
        private IProgramLogRepository _programLogRepo;

        private IProgramTemplateService _programTemplate;
        private IProgramTemplateRepository _programTemplateRepo;

        private IMapper _mapper;

        public ServiceWrapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_userRepo, _mapper);
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
                    _liftingStats = new LiftingStatService(_liftingStatRepo, _mapper);
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
                    _exercise = new ExerciseService(_exerciseRepo, _mapper);
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
                    _exerciseCategory = new ExerciseCategoryService(_exerciseCategoryRepo, _mapper);
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
                    _programLogs = new ProgramLogService(_programLogRepo, _mapper);
                }

                return _programLogs;
            }
        }

        public IProgramTemplateService ProgramTemplate
        {
            get
            {
                if (_programTemplate == null)
                {
                    _programTemplate = new ProgramTemplateService(_programTemplateRepo, _mapper);
                }

                return _programTemplate;
            }
        }
    }
}