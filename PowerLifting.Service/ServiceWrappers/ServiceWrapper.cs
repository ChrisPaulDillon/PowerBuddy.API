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
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.Users.Model;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Services.ProgramLogExercises;
using Powerlifting.Services.ProgramLogRepSchemes.Model;
using PowerLifting.Services.TemplateExercises;
using Powerlifting.Services.TemplateRepSchemes;
using PowerLifting.Services.ProgramLogRepSchemes;
using PowerLifting.Services.ProgramLogRepSchemess;

namespace PowerLifting.Service.ServiceWrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IUserService _user;
        private ILiftingStatService _liftingStats;
        private ILiftingStatAuditService _liftingStatAudit;
        private IExerciseService _exercise;
        private IExerciseCategoryService _exerciseCategory;
        private IProgramLogService _programLog;
        private IProgramLogExerciseService _programLogExercise;
        private ProgramLogRepSchemeService _programLogRepScheme;
        private ITemplateProgramService _templateProgram;
        private ITemplateExerciseService _templateExercise;
        private ITemplateRepSchemeService _templateRepScheme;

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

        public ILiftingStatAuditService LiftingStatAudit
        {
            get
            {
                if(_liftingStatAudit == null)
                {
                    _liftingStatAudit = new LiftingStatAuditService(_repoWrapper, _mapper);
                }

                return _liftingStatAudit;
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
                if (_programLog == null)
                {
                    _programLog = new ProgramLogService(_repoWrapper, _mapper);
                }

                return _programLog;
            }
        }

        public IProgramLogExerciseService ProgramLogExercise
        {
            get
            {
                if (_programLogExercise == null)
                {
                    _programLogExercise = new ProgramLogExerciseService(_repoWrapper, _mapper);
                }

                return _programLogExercise;
            }
        }

        public IProgramLogRepSchemeService ProgramLogRepScheme
        {
            get
            {
                if (_programLogRepScheme == null)
                {
                    _programLogRepScheme = new ProgramLogRepSchemeService(_repoWrapper, _mapper);
                }

                return _programLogRepScheme;
            }
        }

        public ITemplateProgramService TemplateProgram
        {
            get
            {
                if (_templateProgram == null)
                {
                    _templateProgram = new TemplateProgramService(_repoWrapper, _mapper);
                }

                return _templateProgram;
            }
        }

        public ITemplateExerciseService TemplateExercise
        {
            get
            {
                if (_templateExercise == null)
                {
                    _templateExercise = new TemplateExerciseService(_repoWrapper, _mapper);
                }

                return _templateExercise;
            }
        }

        public ITemplateRepSchemeService TemplateRepScheme
        {
            get
            {
                if (_templateRepScheme == null)
                {
                    _templateRepScheme = new TemplateRepSchemeService(_repoWrapper, _mapper);
                }

                return _templateRepScheme;
            }
        }
    }
}