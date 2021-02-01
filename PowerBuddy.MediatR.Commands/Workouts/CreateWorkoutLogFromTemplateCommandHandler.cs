﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Workouts;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.Workouts;
using PowerBuddy.Services.Account;
using PowerBuddy.Services.Templates;
using PowerBuddy.Services.Weights;
using PowerBuddy.Services.Workouts;
using PowerBuddy.Services.Workouts.Factories;
using PowerBuddy.Services.Workouts.Strategies;
using PowerBuddy.Services.Workouts.Util;
using PowerBuddy.SignalR;
using PowerBuddy.SignalR.Models;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.Commands.Workouts
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

    internal class CreateWorkoutLogFromTemplateCommandHandler : IRequestHandler<CreateWorkoutLogFromTemplateCommand, bool>
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

        public async Task<bool> Handle(CreateWorkoutLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
           // await _WorkoutService.IsWorkoutLogAlreadyActive(request.WorkoutInputDTO.StartDate, request.WorkoutInputDTO.EndDate, request.UserId);

           var templateProgram = await _templateService.GetTemplateProgramById(request.TemplateProgramId);
           if (templateProgram.NoOfDaysPerWeek != request.WorkoutInputDTO.DayCount)
           {
               throw new WorkoutDaysDoesNotMatchTemplateDaysException();
           }

           templateProgram.ActiveUsersCount++;
           _templateService.AddTemplateProgramAudit(request.TemplateProgramId, request.UserId, DateTime.UtcNow);

           _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

           var workoutLog = _mapper.Map<WorkoutLog>(request.WorkoutInputDTO);

           var startDate = request.WorkoutInputDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
           var workoutOrder = WorkoutHelper.CalculateDayOrder(workoutLog, startDate);

           workoutLog.WorkoutDays = _workoutService.CreateWorkoutDaysFromTemplate(templateProgram, startDate, workoutOrder, request.WorkoutInputDTO.WeightInputs, _calculateRepWeight, request.UserId); //create weeks based on template weeks
           workoutLog.CustomName ??= templateProgram.Name;

           _context.WorkoutLog.Add(workoutLog);
           var modifiedRows = await _context.SaveChangesAsync(cancellationToken);

           if (modifiedRows > 0)
           {
               //await _hub.SendMessageAllClients(new UserMessage()
               //{
               //    Title = 
               //});
           }
           return modifiedRows > 0;
        }
    }
}
