using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.API.Wrappers;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.Service.Exercises;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.SystemServices.RepSchemeTypes;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.TemplatePrograms;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.Users;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.UserSettings;

namespace PowerLifting.Service
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IExerciseService _exercise;
        private IExerciseMuscleGroupService _exerciseMuscleGroup;
        private IExerciseTypeService _exerciseType;
        private ITemplateDifficultyService _templateDifficultyService;
        private IRepSchemeTypeService _repSchemeTypeService;
        private ILiftingStatService _liftingStats;

        private readonly IMapper _mapper;
        private IProgramLogService _programLog;
        private readonly IRepositoryWrapper _repoWrapper;
        private ITemplateProgramService _templateProgram;
        private IUserService _user;
        private IUserSettingService _userSetting;

        private UserManager<User> _userManager;

        public ServiceWrapper(IMapper mapper, IRepositoryWrapper repoWrapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _repoWrapper = repoWrapper;
            _userManager = userManager;
        }

        public ILiftingStatService LiftingStat
        {
            get
            {
                if (_liftingStats == null) _liftingStats = new LiftingStatService(_repoWrapper, _mapper);

                return _liftingStats;
            }
        }

        public IExerciseService Exercise
        {
            get
            {
                if (_exercise == null) _exercise = new ExerciseService(_repoWrapper, _mapper);

                return _exercise;
            }
        }

        public IExerciseTypeService ExerciseType
        {
            get
            {
                if (_exerciseType == null) _exerciseType = new ExerciseTypeService(_repoWrapper, _mapper);

                return _exerciseType;
            }
        }

        public IExerciseMuscleGroupService ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroup == null)
                    _exerciseMuscleGroup = new ExerciseMuscleGroupService(_repoWrapper, _mapper);

                return _exerciseMuscleGroup;
            }
        }

        public ITemplateDifficultyService TemplateDifficulty
        {
            get
            {
                if (_templateDifficultyService == null)
                    _templateDifficultyService = new TemplateDifficultyService(_repoWrapper, _mapper);

                return _templateDifficultyService;
            }
        }

        public IRepSchemeTypeService RepSchemeType
        {
            get
            {
                if (_repSchemeTypeService == null)
                    _repSchemeTypeService = new RepSchemeTypeService(_repoWrapper, _mapper);

                return _repSchemeTypeService;
            }
        }

        public IProgramLogService ProgramLog
        {
            get
            {
                if (_programLog == null) _programLog = new ProgramLogService(_repoWrapper, _mapper, _userManager);

                return _programLog;
            }
        }

        public ITemplateProgramService TemplateProgram
        {
            get
            {
                if (_templateProgram == null) _templateProgram = new TemplateProgramService(_repoWrapper, _mapper);

                return _templateProgram;
            }
        }

        public IUserService User
        {
            get
            {
                if (_user == null) _user = new UserService(_repoWrapper, _mapper, _userManager);

                return _user;
            }
        }

        public IUserSettingService UserSetting
        {
            get
            {
                if (_userSetting == null) _userSetting = new UserSettingService(_repoWrapper, _mapper);

                return _userSetting;
            }
        }
    }
}