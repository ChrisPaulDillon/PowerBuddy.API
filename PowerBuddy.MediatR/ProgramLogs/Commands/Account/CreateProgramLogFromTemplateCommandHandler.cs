using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.DTOs.Templates;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Services.LiftingStats;
using PowerBuddy.Services.ProgramLogs;
using PowerBuddy.Services.ProgramLogs.Factories;
using PowerBuddy.Services.ProgramLogs.Strategies;
using PowerBuddy.Services.ProgramLogs.Util;
using PowerBuddy.Util.Extensions;

namespace PowerBuddy.MediatR.ProgramLogs.Commands.Account
{
    public class CreateProgramLogFromTemplateCommand : IRequest<ProgramLogDTO>
    {
        public ProgramLogTemplateInputDTO ProgramLogDTO { get; }
        public int TemplateProgramId { get; }
        public string UserId { get; }

        public CreateProgramLogFromTemplateCommand(ProgramLogTemplateInputDTO programLogDTO, int templateProgramId, string userId)
        {
            ProgramLogDTO = programLogDTO;
            TemplateProgramId = templateProgramId;
            UserId = userId;
            new CreateProgramLogFromTemplateCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateProgramLogFromTemplateCommandValidator : AbstractValidator<CreateProgramLogFromTemplateCommand>
    {
        public CreateProgramLogFromTemplateCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.TemplateProgramId).NotNull().GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }
    public class CreateProgramLogFromTemplateCommandHandler : IRequestHandler<CreateProgramLogFromTemplateCommand, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;
        private readonly ILiftingStatService _liftingStatService;
        private readonly ICalculateWeightFactory _calculateWeightFactory;
        private ICalculateRepWeight _calculateRepWeight;

        public CreateProgramLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, ILiftingStatService liftingStatService, ICalculateWeightFactory calculateWeightFactory, ICalculateRepWeight calculateRepWeight)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _liftingStatService = liftingStatService;
            _calculateWeightFactory = calculateWeightFactory;
            _calculateRepWeight = calculateRepWeight;
        }

        public async Task<ProgramLogDTO> Handle(CreateProgramLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
            await _programLogService.IsProgramLogAlreadyActive(request.ProgramLogDTO.StartDate, request.ProgramLogDTO.EndDate, request.UserId);

            var templateProgram = await _programLogService.GetTemplateProgramById(request.TemplateProgramId);
            if (templateProgram.NoOfDaysPerWeek != request.ProgramLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();
            var templateWeeks = templateProgram.TemplateWeeks.ToList();

            _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            var programLogWeeks = programLog.ProgramLogWeeks.ToList();
            var startDate = request.ProgramLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
            

            for (var i = 0; i < request.ProgramLogDTO.RepeatProgramCount; i++)
            {
                programLogWeeks.AddRange(_programLogService.CreateProgramLogWeeksFromTemplate(templateProgram, startDate, i, request.UserId)); //create weeks based on template weeks
                startDate = startDate.AddDays(programLog.NoOfWeeks * 7);
            }

            programLog.ProgramLogWeeks = programLogWeeks;
            programLog.StartDate = request.ProgramLogDTO.StartDate.StartOfWeek(DayOfWeek.Monday);
            programLog.EndDate = programLog.StartDate.AddDays((programLog.NoOfWeeks * request.ProgramLogDTO.RepeatProgramCount) * 7);

            var incrementWeightsDic = new Dictionary<int, decimal>();
            if (request.ProgramLogDTO.IncrementalWeightInputs != null && request.ProgramLogDTO.IncrementalWeightInputs.Any())
            {
                incrementWeightsDic = request.ProgramLogDTO.IncrementalWeightInputs.ToDictionary(x => x.ExerciseId, x => (decimal)x.Weight);
            }

            var templateWeek = new TemplateWeekDTO();
            var programDayOrder = ProgramLogHelper.CalculateDayOrder(programLog);
            var currentWeightInputs = request.ProgramLogDTO.WeightInputs;
            var counter = 0;

            //Apply exercises to days that have exercises on them
            foreach (var programLogWeek in programLog.ProgramLogWeeks)
            {
                templateWeek = templateWeeks[counter++];

                if (counter >= templateProgram.NoOfWeeks) //reset the templates back to week 1 for new cycle
                {
                    currentWeightInputs = _liftingStatService.CalculateNewWeightInput(currentWeightInputs, incrementWeightsDic);
                    counter = 0;
                }

                var dayCounter = 0;
                foreach (var programLogDay in programLogWeek.ProgramLogDays)
                {
                    if (dayCounter >= programDayOrder.Count) break; //We have already populated all exercises for this week

                    if (_programLogService.IsDateOnWorkoutDay(programLogDay.Date, programDayOrder, dayCounter)) //we have found a workout date
                    {
                        var templateDay = templateWeek.TemplateDays.ToList()[dayCounter++];
                        programLogDay.ProgramLogExercises = _programLogService.CreateProgramLogExercisesForTemplateDay(templateDay, currentWeightInputs, _calculateRepWeight, request.UserId);
                    }
                }
            }

            _context.ProgramLog.Add(programLog);
            await _context.SaveChangesAsync(cancellationToken);

            var createdProgramLog = _mapper.Map<ProgramLogDTO>(programLog);
            return createdProgramLog;
        }
    }
}
