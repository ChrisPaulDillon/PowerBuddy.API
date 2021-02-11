using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.App.Services.Templates;
using PowerBuddy.App.Services.Workouts;
using PowerBuddy.App.Services.Workouts.Factories;
using PowerBuddy.App.Services.Workouts.Strategies;
using PowerBuddy.App.Services.Workouts.Util;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.TemplatePrograms;
using PowerBuddy.Data.Models.Workouts;
using PowerBuddy.SignalR;
using PowerBuddy.SignalR.Models;
using PowerBuddy.SignalR.Util;
using PowerBuddy.Util;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Commands.Workouts
{
    public class CreateWorkoutLogFromTemplateCommand : IRequest<OneOf<bool, WorkoutLogExistsOnDate, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>>
    {
        public WorkoutLogTemplateInputDto WorkoutInputDto { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateWorkoutLogFromTemplateCommand(WorkoutLogTemplateInputDto workoutInputDto, int templateProgramId, string userId)
        {
            WorkoutInputDto = workoutInputDto;
            TemplateProgramId = templateProgramId;
            UserId = userId;
        }
    }

    public class CreateWorkoutLogFromTemplateCommandValidator : AbstractValidator<CreateWorkoutLogFromTemplateCommand>
    {
        public CreateWorkoutLogFromTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
            RuleFor(x => x.WorkoutInputDto.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutInputDto.CustomName).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
            RuleFor(x => x.WorkoutInputDto.CustomName).MaximumLength(30).WithMessage(ValidationConstants.MAX_LENGTH);
            RuleFor(x => x.WorkoutInputDto.Monday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Tuesday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Wednesday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Thursday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Friday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Saturday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.Sunday).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.WorkoutInputDto.WeightInputs.Count()).GreaterThan(0).WithMessage(ValidationConstants.GREATER_THAN);
        }
    }

    public class CreateWorkoutLogFromTemplateCommandHandler : IRequestHandler<CreateWorkoutLogFromTemplateCommand, OneOf<bool, WorkoutLogExistsOnDate, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IWorkoutService _workoutService;
        private readonly ITemplateService _templateService;
        private readonly ICalculateWeightFactory _calculateWeightFactory;
        private readonly IHubContext<MessageHub> _hub;
        private ICalculateRepWeight _calculateRepWeight;

        public CreateWorkoutLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IWorkoutService workoutService, ITemplateService templateService, ICalculateWeightFactory calculateWeightFactory, IHubContext<MessageHub> hub, ICalculateRepWeight calculateRepWeight)
        {
            _context = context;
            _mapper = mapper;
            _workoutService = workoutService;
            _templateService = templateService;
            _calculateWeightFactory = calculateWeightFactory;
            _calculateRepWeight = calculateRepWeight;
            _hub = hub;
        }

        public async Task<OneOf<bool, WorkoutLogExistsOnDate, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>> Handle(CreateWorkoutLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
            var doesLogExistOnDate = await _workoutService.DoesWorkoutLogExistOnDates(request.WorkoutInputDto.StartDate, request.UserId);

            if (doesLogExistOnDate)
            {
                return new WorkoutLogExistsOnDate();
            }

           var templateProgram = await _templateService.GetTemplateProgramById(request.TemplateProgramId);
           if (templateProgram == null)
           {
               return new TemplateProgramNotFound();
           }

           if (templateProgram.NoOfDaysPerWeek != request.WorkoutInputDto.DayCount)
           {
               return new WorkoutDaysDoesNotMatchTemplateDays();
           }

           templateProgram.ActiveUsersCount++;
           _templateService.AddTemplateProgramAudit(request.TemplateProgramId, request.UserId, DateTime.UtcNow);

           _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

           var workoutLog = _mapper.Map<WorkoutLog>(request.WorkoutInputDto);

           var startDate = request.WorkoutInputDto.StartDate.StartOfWeek(DayOfWeek.Monday);
           var workoutOrder = WorkoutHelper.CalculateDayOrder(workoutLog, startDate);

           workoutLog.WorkoutDays = _workoutService.CreateWorkoutDaysFromTemplate(templateProgram, startDate, workoutOrder, request.WorkoutInputDto.WeightInputs, _calculateRepWeight, request.UserId); //create weeks based on template weeks
           workoutLog.CustomName ??= templateProgram.Name;

           await _context.WorkoutLog.AddAsync(workoutLog, cancellationToken);
           var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

           if (modifiedRows > 0)
           {
               var userName = await _context.User
                   .AsNoTracking()
                   .Where(x => x.Id == request.UserId)
                   .Select(x => x.UserName)
                   .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                await _hub.Clients.All.SendAsync(SignalRConstants.MESSAGE_METHOD_ALL, new UserMessage()
                {
                    UserName = userName,
                    Body = $"{userName} just started the program {templateProgram.Name}!"
                }, cancellationToken: cancellationToken);
           }
           return modifiedRows > 0;
        }
    }
}
