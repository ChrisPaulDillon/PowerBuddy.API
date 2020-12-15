//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using FluentValidation;
//using MediatR;
//using PowerBuddy.Context;
//using PowerBuddy.Data.DTOs.ProgramLogs;
//using PowerBuddy.Data.Entities;
//using PowerBuddy.Data.Exceptions.ProgramLogs;
//using PowerBuddy.Services.LiftingStats;
//using PowerBuddy.Services.ProgramLogs.Factories;
//using PowerBuddy.Services.ProgramLogs.Strategies;
//using PowerBuddy.Services.ProgramLogs.Util;
//using PowerBuddy.Services.Templates;
//using PowerBuddy.Services.Workouts;
//using PowerBuddy.Util.Extensions;

//namespace PowerBuddy.MediatR.Workouts.Commands
//{
//    public class CreateWorkoutLogFromTemplateCommand : IRequest<bool>
//    {
//        public ProgramLogTemplateInputDTO WorkoutLogDTO { get; }
//        public int TemplateProgramId { get; }
//        public string UserId { get; }

//        public CreateWorkoutLogFromTemplateCommand(ProgramLogTemplateInputDTO workoutLogDTO, int templateProgramId, string userId)
//        {
//            WorkoutLogDTO = workoutLogDTO;
//            TemplateProgramId = templateProgramId;
//            UserId = userId;
//            new CreateWorkoutLogFromTemplateCommandValidator().ValidateAndThrow(this);
//        }
//    }

//    public class CreateWorkoutLogFromTemplateCommandValidator : AbstractValidator<CreateWorkoutLogFromTemplateCommand>
//    {
//        public CreateWorkoutLogFromTemplateCommandValidator()
//        {
//            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
//            RuleFor(x => x.TemplateProgramId).NotNull().GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
//        }
//    }
//    public class CreateWorkoutLogFromTemplateCommandHandler : IRequestHandler<CreateWorkoutLogFromTemplateCommand, bool>
//    {
//        private readonly PowerLiftingContext _context;
//        private readonly IMapper _mapper;
//        private readonly IWorkoutService _workoutService;
//        private readonly ILiftingStatService _liftingStatService;
//        private readonly ITemplateService _templateService;
//        private readonly ICalculateWeightFactory _calculateWeightFactory;
//        private ICalculateRepWeight _calculateRepWeight;

//        public CreateWorkoutLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService WorkoutService, ILiftingStatService liftingStatService, ITemplateService templateService, ICalculateWeightFactory calculateWeightFactory, ICalculateRepWeight calculateRepWeight)
//        {
//            _context = context;
//            _mapper = mapper;
//            _workoutService = WorkoutService;
//            _liftingStatService = liftingStatService;
//            _templateService = templateService;
//            _calculateWeightFactory = calculateWeightFactory;
//            _calculateRepWeight = calculateRepWeight;
//        }

//        public async Task<bool> Handle(CreateWorkoutLogFromTemplateCommand request, CancellationToken cancellationToken)
//        {
//           // await _WorkoutService.IsWorkoutLogAlreadyActive(request.WorkoutLogDTO.StartDate, request.WorkoutLogDTO.EndDate, request.UserId);

//            var templateProgram = await _templateService.GetTemplateProgramById(request.TemplateProgramId);
//            if (templateProgram.NoOfDaysPerWeek != request.WorkoutLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();
//            var templateWeeks = templateProgram.TemplateWeeks.ToList();

//            templateProgram.ActiveUsersCount++;
//            _templateService.AddTemplateProgramAudit(request.TemplateProgramId, request.UserId, DateTime.UtcNow);

//            _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

//            var workoutLog = _mapper.Map<WorkoutLog>(request.WorkoutLogDTO);

//            var workoutLogDays = new List<WorkoutDay>();
//            var startDate = request.WorkoutLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);


//            for (var i = 0; i < request.WorkoutLogDTO.RepeatProgramCount; i++)
//            {
//                workoutLogDays.AddRange(_workoutService.CreateWorkoutLogWeeksFromTemplate(templateProgram, startDate, i, request.UserId)); //create weeks based on template weeks
//                startDate = startDate.AddDays(workoutLog.NoOfWeeks * 7);
//            }

//            workoutLog.WorkoutLogWeeks = WorkoutLogWeeks;
//            workoutLog.StartDate = request.WorkoutLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
//            workoutLog.EndDate = WorkoutLog.StartDate.AddDays((WorkoutLog.NoOfWeeks * request.WorkoutLogDTO.RepeatProgramCount) * 7);

//            var incrementWeightsDic = new Dictionary<int, decimal>();
//            if (request.WorkoutLogDTO.IncrementalWeightInputs != null && request.WorkoutLogDTO.IncrementalWeightInputs.Any() && request.WorkoutLogDTO.RepeatProgramCount > 1)
//            {
//                incrementWeightsDic = request.WorkoutLogDTO.IncrementalWeightInputs.ToDictionary(x => x.ExerciseId, x => (decimal)x.Weight);
//            }

//            var templateWeek = new TemplateWeek();
//            var programDayOrder = ProgramLogHelper.CalculateDayOrder(workoutLog);
//            var currentWeightInputs = request.WorkoutLogDTO.WeightInputs;
//            var counter = 0;

//            //Apply exercises to days that have exercises on them
//            foreach (var WorkoutLogWeek in WorkoutLog.WorkoutLogWeeks)
//            {
//                templateWeek = templateWeeks[counter++];

//                if (counter >= templateProgram.NoOfWeeks && request.WorkoutLogDTO.RepeatProgramCount > 1) //reset the templates back to week 1 for new cycle
//                {
//                    currentWeightInputs = _liftingStatService.CalculateNewWeightInput(currentWeightInputs, incrementWeightsDic);
//                    counter = 0;
//                }

//                var dayCounter = 0;
//                foreach (var WorkoutLogDay in WorkoutLogWeek.WorkoutLogDays)
//                {
//                    if (dayCounter >= programDayOrder.Count) break; //We have already populated all exercises for this week

//                    if (_WorkoutLogService.IsDateOnWorkoutDay(WorkoutLogDay.Date, programDayOrder, dayCounter)) //we have found a workout date
//                    {
//                        var templateDay = templateWeek.TemplateDays.ToList()[dayCounter++];
//                        WorkoutLogDay.WorkoutLogExercises = _WorkoutLogService.CreateWorkoutLogExercisesForTemplateDay(templateDay, currentWeightInputs, _calculateRepWeight, request.UserId);
//                    }
//                }
//            }

//            _context.WorkoutLog.Add(WorkoutLog);
//            await _context.SaveChangesAsync(cancellationToken);

//            var createdWorkoutLog = _mapper.Map<WorkoutLogDTO>(WorkoutLog);
//            return createdWorkoutLog;
//        }
//    }
//}
