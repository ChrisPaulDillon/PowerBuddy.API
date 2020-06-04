using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Accounts.Contracts;
using PowerLifting.Accounts.Contracts.Services;
using PowerLifting.Accounts.Service;
using PowerLifting.LiftingStats.Service;
using PowerLifting.ProgramLogs.Contracts;
using PowerLifting.ProgramLogs.Service;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.SystemServices.TemplateDifficultys;
using PowerLifting.Service.Users;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.UserSettings;
using PowerLifting.Systems.Contracts;
using PowerLifting.Systems.Contracts.Services;
using PowerLifting.Systems.Service;
using PowerLifting.Systems.Service.Services;
using PowerLifting.TemplatePrograms.Contracts;
using PowerLifting.TemplatePrograms.Contracts.Services;
using PowerLifting.TemplatePrograms.Service;

namespace PowerLifting.API.Wrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IExerciseService _exercise;
        private IExerciseMuscleGroupService _exerciseMuscleGroup;
        private IExerciseTypeService _exerciseType;
        private IRepSchemeTypeService _repSchemeTypeService;
        private ILiftingStatService _liftingStats;
        private IProgramLogService _programLog;
        private ITemplateProgramService _templateProgram;
        private ITemplateDifficultyService _templateDifficultyService;
        private ITemplateExerciseCollectionService _templateExerciseCollection;
        private IUserService _user;
        private IUserSettingService _userSetting;

        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _programLogWrapper;
        private readonly ITemplateProgramWrapper _templateProgramWrapper;
        private readonly ISystemWrapper _systemWrapper;
        private readonly IAccountWrapper _accountWrapper;
        private readonly ILiftingStatsWrapper _liftingStatsWrapper;

        private UserManager<User> _userManager;

        public ServiceWrapper(IMapper mapper, IProgramLogWrapper programLogWrapper, ITemplateProgramWrapper templateProgramWrapper, ISystemWrapper systemWrapper, ILiftingStatsWrapper liftingStatsWrapper, IAccountWrapper accountWrapper,  UserManager<User> userManager)
        {
            _mapper = mapper;
            _programLogWrapper = programLogWrapper;
            _templateProgramWrapper = templateProgramWrapper;
            _systemWrapper = systemWrapper;
            _accountWrapper = accountWrapper;
            _liftingStatsWrapper = liftingStatsWrapper;
            _userManager = userManager;
        }

        public ILiftingStatService LiftingStat
        {
            get
            {
                if (_liftingStats == null) _liftingStats = new LiftingStatService(_liftingStatsWrapper, _mapper);

                return _liftingStats;
            }
        }

        public IExerciseService Exercise
        {
            get
            {
                if (_exercise == null) _exercise = new ExerciseService(_systemWrapper, _mapper);

                return _exercise;
            }
        }

        public IExerciseTypeService ExerciseType
        {
            get
            {
                if (_exerciseType == null) _exerciseType = new ExerciseTypeService(_systemWrapper, _mapper);

                return _exerciseType;
            }
        }

        public IExerciseMuscleGroupService ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroup == null)
                    _exerciseMuscleGroup = new ExerciseMuscleGroupService(_systemWrapper, _mapper);

                return _exerciseMuscleGroup;
            }
        }

        public ITemplateDifficultyService TemplateDifficulty
        {
            get
            {
                if (_templateDifficultyService == null)
                    _templateDifficultyService = new TemplateDifficultyService(_systemWrapper, _mapper);

                return _templateDifficultyService;
            }
        }

        public IRepSchemeTypeService RepSchemeType
        {
            get
            {
                if (_repSchemeTypeService == null)
                    _repSchemeTypeService = new RepSchemeTypeService(_systemWrapper, _mapper);

                return _repSchemeTypeService;
            }
        }

        public IProgramLogService ProgramLog
        {
            get
            {
                if (_programLog == null) _programLog = new ProgramLogService(_programLogWrapper, _mapper, _userManager);

                return _programLog;
            }
        }
        public ITemplateExerciseCollectionService TemplateExerciseCollection
        {
            get
            {
                if (_templateExerciseCollection == null)
                    _templateExerciseCollection = new TemplateExerciseCollectionService(_templateProgramWrapper, _mapper);

                return _templateExerciseCollection;
            }
        }

        public ITemplateProgramService TemplateProgram
        {
            get
            {
                if (_templateProgram == null) _templateProgram = new TemplateProgramService(_templateProgramWrapper, _mapper);

                return _templateProgram;
            }
        }

        public IUserService User
        {
            get
            {
                if (_user == null) _user = new UserService(_accountWrapper, _mapper, _userManager);

                return _user;
            }
        }

        public IUserSettingService UserSetting
        {
            get
            {
                if (_userSetting == null) _userSetting = new UserSettingService(_accountWrapper, _mapper);

                return _userSetting;
            }
        }
    }
}