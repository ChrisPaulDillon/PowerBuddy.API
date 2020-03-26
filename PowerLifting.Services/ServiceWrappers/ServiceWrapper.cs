using AutoMapper;
using Powerlifting.Services.Users;
using Powerlifting.Service.ExerciseCategories;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.ProgramTemplates;
using Powerlifting.Service.Exercises;
using Powerlifting.Service.LiftingStats;

namespace Powerlifting.Services.ServiceWrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private PowerliftingContext _repoContext;
        private IUserService _user;
        private ILiftingStatService _liftingStats;
        private IExerciseService _exercise;
        private IExerciseCategoryService _exerciseCategory;
        private IProgramLogService _programLogs;
        private IProgramTemplateService _programTemplate;
        private IMapper _mapper;

        public ServiceWrapper(PowerliftingContext ServiceContext, IMapper mapper)
        {
            _repoContext = ServiceContext;
            _mapper = mapper;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoContext, _mapper);
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
                    _liftingStats = new LiftingStatService(_repoContext, _mapper);
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
                    _exercise = new ExerciseService(_repoContext, _mapper);
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
                    _exerciseCategory = new ExerciseCategoryService(_repoContext, _mapper);
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
                    _programLogs = new ProgramLogService(_repoContext, _mapper);
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
                    _programTemplate = new ProgramTemplateService(_repoContext, _mapper);
                }

                return _programTemplate;
            }
        }


        public void Save()
        {
            _repoContext.SaveChangesAsync();
        }
    }
}