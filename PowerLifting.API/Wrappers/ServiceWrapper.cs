using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PowerLifting.Accounts.Service;
using PowerLifting.Accounts.Service.Wrapper;
using PowerLifting.Data;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Exercises.Service;
using PowerLifting.Exercises.Service.Wrapper;
using PowerLifting.LiftingStats.Service;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service;
using PowerLifting.ProgramLogs.Service.Wrapper;
using PowerLifting.Systems.Service;
using PowerLifting.TemplatePrograms.Service;
using PowerLifting.TemplatePrograms.Service.Wrapper;

namespace PowerLifting.API.Wrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IExerciseService _exercise;
        private IExerciseMuscleGroupService _exerciseMuscleGroup;
        private IExerciseTypeService _exerciseType;
        private IRepSchemeTypeService _repSchemeTypeService;
        private IQuoteService _quoteService;

        private ILiftingStatService _liftingStats;
        private IProgramLogService _programLog;
        private IProgramLogDayService _programLogDay;
        private IProgramLogRepSchemeService _programLogRepScheme;
        private IProgramLogExerciseService _programLogExercise;
        private ITemplateProgramService _templateProgram;
        private ITemplateDifficultyService _templateDifficultyService;
        private ITemplateExerciseCollectionService _templateExerciseCollection;
        private IUserService _user;
        private IUserSettingService _userSetting;
        private INotificationService _notification;
        private IFriendsListService _friendsList;

        private readonly IMapper _mapper;
        private readonly IProgramLogWrapper _programLogWrapper;
        private readonly ITemplateProgramWrapper _templateProgramWrapper;
        private readonly ISystemWrapper _systemWrapper;
        private readonly IAccountWrapper _accountWrapper;
        private readonly ILiftingStatsWrapper _liftingStatsWrapper;
        private readonly IExerciseWrapper _exerciseWrapper;

        private readonly UserManager<User> _userManager;
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly PowerLiftingContext _context;

        public ServiceWrapper(PowerLiftingContext context, IMapper mapper, IProgramLogWrapper programLogWrapper, ITemplateProgramWrapper templateProgramWrapper, ISystemWrapper systemWrapper, ILiftingStatsWrapper liftingStatsWrapper, IAccountWrapper accountWrapper, UserManager<User> userManager, IOptions<ApplicationSettings> appSettings, IExerciseWrapper exerciseWrapper)
        {
            _context = context;
            _mapper = mapper;
            _programLogWrapper = programLogWrapper;
            _templateProgramWrapper = templateProgramWrapper;
            _systemWrapper = systemWrapper;
            _accountWrapper = accountWrapper;
            _liftingStatsWrapper = liftingStatsWrapper;
            _userManager = userManager;
            _appSettings = appSettings;
            _exerciseWrapper = exerciseWrapper;
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
                if (_exercise == null) _exercise = new ExerciseService(_context, _exerciseWrapper, _mapper);

                return _exercise;
            }
        }

        public IExerciseTypeService ExerciseType
        {
            get
            {
                if (_exerciseType == null) _exerciseType = new ExerciseTypeService(_exerciseWrapper, _mapper);

                return _exerciseType;
            }
        }

        public IExerciseMuscleGroupService ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroup == null)
                    _exerciseMuscleGroup = new ExerciseMuscleGroupService(_exerciseWrapper, _mapper);

                return _exerciseMuscleGroup;
            }
        }

        public IQuoteService Quote
        {
            get
            {
                if (_quoteService == null)
                    _quoteService = new QuoteService(_systemWrapper, _mapper);

                return _quoteService;
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

        public IProgramLogDayService ProgramLogDay
        {
            get
            {
                if (_programLogDay == null) _programLogDay = new ProgramLogDayService(_programLogWrapper, _mapper);

                return _programLogDay;
            }
        }

        public IProgramLogExerciseService ProgramLogExercise
        {
            get
            {
                if (_programLogExercise == null) _programLogExercise = new ProgramLogExerciseService(_programLogWrapper, _mapper, _userManager);

                return _programLogExercise;
            }
        }

        public IProgramLogRepSchemeService ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepScheme == null) _programLogRepScheme = new ProgramLogRepSchemeService(_programLogWrapper, _mapper, _userManager);

                return _programLogRepScheme;
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
                if (_user == null) _user = new UserService(_accountWrapper, _mapper, _userManager, _appSettings);

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

        public INotificationService Notification
        {
            get
            {
                if (_notification == null) _notification = new NotificationService(_accountWrapper, _mapper);

                return _notification;
            }
        }

        public IFriendsListService FriendsList
        {
            get
            {
                if (_friendsList == null) _friendsList = new FriendsListService(_accountWrapper, _mapper, _userManager);

                return _friendsList;
            }
        }
    }
}