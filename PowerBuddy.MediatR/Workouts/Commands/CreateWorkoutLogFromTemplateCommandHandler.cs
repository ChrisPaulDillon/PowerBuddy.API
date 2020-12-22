using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Services.Workouts.Util;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.Workouts.Commands
{
    public class CreateWorkoutLogFromTemplateCommand : IRequest<bool>
    {
        public WorkoutLogTemplateInputDTO WorkoutInputDTO { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateWorkoutLogFromTemplateCommand(WorkoutLogTemplateInputDTO workoutInputDTO, int templateProgramId, string userId)
        {
            WorkoutInputDTO = workoutInputDTO;
            TemplateProgramId = templateProgramId;
            UserId = userId;
            new CreateWorkoutLogFromTemplateCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateWorkoutLogFromTemplateCommandValidator : AbstractValidator<CreateWorkoutLogFromTemplateCommand>
    {
        public CreateWorkoutLogFromTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).NotNull().GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }
    public class CreateWorkoutLogFromTemplateCommandHandler : IRequestHandler<CreateWorkoutLogFromTemplateCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;
        private readonly ILiftingStatService _liftingStatService;
        private readonly ITemplateService _templateService;
        private readonly ICalculateWeightFactory _calculateWeightFactory;
        private ICalculateRepWeight _calculateRepWeight;

        public CreateWorkoutLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService WorkoutService, ILiftingStatService liftingStatService, ITemplateService templateService, ICalculateWeightFactory calculateWeightFactory, ICalculateRepWeight calculateRepWeight)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = WorkoutService;
            _liftingStatService = liftingStatService;
            _templateService = templateService;
            _calculateWeightFactory = calculateWeightFactory;
            _calculateRepWeight = calculateRepWeight;
        }

        public async Task<bool> Handle(CreateWorkoutLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
           // await _WorkoutService.IsWorkoutLogAlreadyActive(request.WorkoutInputDTO.StartDate, request.WorkoutInputDTO.EndDate, request.UserId);

            var templateProgram = await _templateService.GetTemplateProgramById(request.TemplateProgramId);
            if (templateProgram.NoOfDaysPerWeek != request.WorkoutInputDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

            templateProgram.ActiveUsersCount++;
            _templateService.AddTemplateProgramAudit(request.TemplateProgramId, request.UserId, DateTime.UtcNow);

            _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

            var workoutLog = _mapper.Map<WorkoutLog>(request.WorkoutInputDTO);

            workoutLog.StartDate = request.WorkoutInputDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
            var workoutOrder = WorkoutHelper.CalculateDayOrder(workoutLog);

            workoutLog.WorkoutDays = _workoutService.CreateWorkoutDaysFromTemplate(templateProgram, workoutLog.StartDate, workoutOrder, request.WorkoutInputDTO.WeightInputs, _calculateRepWeight, request.UserId); //create weeks based on template weeks
            workoutLog.EndDate = workoutLog.StartDate.AddDays(templateProgram.NoOfWeeks * 7);
            workoutLog.CustomName ??= templateProgram.Name;

            _context.WorkoutLog.Add(workoutLog);
            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

            return modifiedRows > 0;
        }
    }
}
