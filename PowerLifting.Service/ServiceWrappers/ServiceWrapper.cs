﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PowerLifting.Service.Exercises;
using PowerLifting.Service.Exercises.Contracts;
using PowerLifting.Service.LiftingStats;
using PowerLifting.Service.LiftingStatsAudit;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Contracts.Services;
using PowerLifting.Service.TemplatePrograms;
using PowerLifting.Service.TemplatePrograms.Contracts.Services;
using PowerLifting.Service.Users;
using PowerLifting.Service.Users.Model;

namespace PowerLifting.Service.ServiceWrappers
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IExerciseService _exercise;
        private IExerciseMuscleGroupService _exerciseMuscleGroup;
        private IExerciseTypeService _exerciseType;
        private ILiftingStatAuditService _liftingStatAudit;
        private ILiftingStatService _liftingStats;

        private readonly IMapper _mapper;
        private IProgramLogService _programLog;
        private readonly IRepositoryWrapper _repoWrapper;
        private ITemplateExerciseService _templateExercise;
        private ITemplateProgramService _templateProgram;
        private ITemplateRepSchemeService _templateRepScheme;
        private IUserService _user;

        private UserManager<User> _userManager;

        public ServiceWrapper(IMapper mapper, IRepositoryWrapper repoWrapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _repoWrapper = repoWrapper;
            _userManager = userManager;
        }

        public IUserService User
        {
            get
            {
                if (_user == null) _user = new UserService(_repoWrapper, _mapper);

                return _user;
            }
        }

        public ILiftingStatService LiftingStat
        {
            get
            {
                if (_liftingStats == null) _liftingStats = new LiftingStatService(_repoWrapper, _mapper);

                return _liftingStats;
            }
        }

        public ILiftingStatAuditService LiftingStatAudit
        {
            get
            {
                if (_liftingStatAudit == null) _liftingStatAudit = new LiftingStatAuditService(_repoWrapper, _mapper);

                return _liftingStatAudit;
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

        public ITemplateExerciseService TemplateExercise
        {
            get
            {
                if (_templateExercise == null) _templateExercise = new TemplateExerciseService(_repoWrapper, _mapper);

                return _templateExercise;
            }
        }

        public ITemplateRepSchemeService TemplateRepScheme
        {
            get
            {
                if (_templateRepScheme == null)
                    _templateRepScheme = new TemplateRepSchemeService(_repoWrapper, _mapper);

                return _templateRepScheme;
            }
        }
    }
}