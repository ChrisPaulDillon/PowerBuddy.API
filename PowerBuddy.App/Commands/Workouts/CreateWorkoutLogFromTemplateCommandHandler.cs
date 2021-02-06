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
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.App.Commands.Workouts
{
    public class CreateWorkoutLogFromTemplateCommand : IRequest<OneOf<bool, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>>
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
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }

    public class CreateWorkoutLogFromTemplateCommandHandler : IRequestHandler<CreateWorkoutLogFromTemplateCommand, OneOf<bool, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>>
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

        public async Task<OneOf<bool, WorkoutDaysDoesNotMatchTemplateDays, TemplateProgramNotFound>> Handle(CreateWorkoutLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
           // await _WorkoutService.IsWorkoutLogAlreadyActive(request.WorkoutInputDto.StartDate, request.WorkoutInputDto.EndDate, request.UserId);

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
