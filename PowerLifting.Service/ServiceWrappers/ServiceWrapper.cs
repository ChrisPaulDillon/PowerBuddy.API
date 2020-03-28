using AutoMapper;
using Powerlifting.Service.ExerciseCategories;
using Powerlifting.Services.ProgramLogs;
using Powerlifting.Services.TemplatePrograms;
using Powerlifting.Service.Exercises;
using Powerlifting.Service.LiftingStats;
using Powerlifting.Service.ProgramLogs;
using PowerLifting.Service.Users;
using PowerLifting.Service.Exercises;
using PowerLifting.Service.TemplatePrograms;

namespace PowerLifting.Service.ServiceWrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private ILiftingStatService _liftingStats;
        private IExerciseService _exercise;
        private IExerciseCategoryService _exerciseCategory;
        private IProgramLogService _programLogs;
        private ITemplateProgramService _programTemplate;

        private IMapper _mapper;
        private IRepositoryWrapper _repoWrapper;

        public ServiceWrapper(IMapper mapper, IRepositoryWrapper repoWrapper)
        {
            _mapper = mapper;
            _repoWrapper = repoWrapper;
        }

        public IUserService User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserService(_repoWrapper, _mapper);
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
                    _liftingStats = new LiftingStatService(_repoWrapper, _mapper);
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
                    _exercise = new ExerciseService(_repoWrapper, _mapper);
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
                    _exerciseCategory = new ExerciseCategoryService(_repoWrapper, _mapper);
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
                    _programLogs = new ProgramLogService(_repoWrapper, _mapper);
                }

                return _programLogs;
            }
        }

        public ITemplateProgramService TemplateProgram
        {
            get
            {
                if (_programTemplate == null)
                {
                    _programTemplate = new TemplateProgramService(_repoWrapper, _mapper);
                }

                return _programTemplate;
            }
        }
    }
}