using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PowerLifting.Accounts.Service;
using PowerLifting.Data;
using PowerLifting.Data.Entities.Account;
using PowerLifting.Exercises.Service;
using PowerLifting.LiftingStats.Service;
using PowerLifting.Persistence;
using PowerLifting.ProgramLogs.Service;
using PowerLifting.Systems.Service;
using PowerLifting.TemplatePrograms.Service;

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

        private readonly UserManager<User> _userManager;
        private readonly IOptions<ApplicationSettings> _appSettings;
        private readonly PowerLiftingContext _context;

        public ServiceWrapper(PowerLiftingContext context, IMapper mapper, UserManager<User> userManager, IOptions<ApplicationSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _appSettings = appSettings;
        }

        public ILiftingStatService LiftingStat
        {
            get
            {
                if (_liftingStats == null) _liftingStats = new LiftingStatService(_context, _mapper);

                return _liftingStats;
            }
        }

        public IExerciseService Exercise
        {
            get
            {
                if (_exercise == null) _exercise = new ExerciseService(_context, _mapper);

                return _exercise;
            }
        }

        public IExerciseTypeService ExerciseType
        {
            get
            {
                if (_exerciseType == null) _exerciseType = new ExerciseTypeService(_context, _mapper);

                return _exerciseType;
            }
        }

        public IExerciseMuscleGroupService ExerciseMuscleGroup
        {
            get
            {
                if (_exerciseMuscleGroup == null)
                    _exerciseMuscleGroup = new ExerciseMuscleGroupService(_context, _mapper);

                return _exerciseMuscleGroup;
            }
        }

        public IQuoteService Quote
        {
            get
            {
                if (_quoteService == null)
                    _quoteService = new QuoteService(_context, _mapper);

                return _quoteService;
            }
        }

        public ITemplateDifficultyService TemplateDifficulty
        {
            get
            {
                if (_templateDifficultyService == null)
                    _templateDifficultyService = new TemplateDifficultyService(_context, _mapper);

                return _templateDifficultyService;
            }
        }

        public IRepSchemeTypeService RepSchemeType
        {
            get
            {
                if (_repSchemeTypeService == null)
                    _repSchemeTypeService = new RepSchemeTypeService(_context, _mapper);

                return _repSchemeTypeService;
            }
        }

        public IProgramLogService ProgramLog
        {
            get
            {
                if (_programLog == null) _programLog = new ProgramLogService(_context, _mapper);

                return _programLog;
            }
        }

        public IProgramLogDayService ProgramLogDay
        {
            get
            {
                if (_programLogDay == null) _programLogDay = new ProgramLogDayService(_context, _mapper);

                return _programLogDay;
            }
        }

        public IProgramLogExerciseService ProgramLogExercise
        {
            get
            {
                if (_programLogExercise == null) _programLogExercise = new ProgramLogExerciseService(_context, _mapper);

                return _programLogExercise;
            }
        }

        public IProgramLogRepSchemeService ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepScheme == null) _programLogRepScheme = new ProgramLogRepSchemeService(_context, _mapper);

                return _programLogRepScheme;
            }
        }

        public ITemplateExerciseCollectionService TemplateExerciseCollection
        {
            get
            {
                if (_templateExerciseCollection == null)
                    _templateExerciseCollection = new TemplateExerciseCollectionService(_context, _mapper);

                return _templateExerciseCollection;
            }
        }

        public ITemplateProgramService TemplateProgram
        {
            get
            {
                if (_templateProgram == null) _templateProgram = new TemplateProgramService(_context, _mapper);

                return _templateProgram;
            }
        }

        public IUserService User
        {
            get
            {
                if (_user == null) _user = new UserService(_context, _mapper, _userManager, _appSettings);

                return _user;
            }
        }

        public IUserSettingService UserSetting
        {
            get
            {
                if (_userSetting == null) _userSetting = new UserSettingService(_context, _mapper);

                return _userSetting;
            }
        }

        public INotificationService Notification
        {
            get
            {
                if (_notification == null) _notification = new NotificationService(_context, _mapper);

                return _notification;
            }
        }

        public IFriendsListService FriendsList
        {
            get
            {
                if (_friendsList == null) _friendsList = new FriendsListService(_context, _mapper, _userManager);

                return _friendsList;
            }
        }
    }
}