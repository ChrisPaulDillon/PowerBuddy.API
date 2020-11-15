using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Factories;
using PowerLifting.Service.ProgramLogs.Strategies;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.MediatR.ProgramLogs.Commands.Account
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
        private readonly ICalculateWeightFactory _calculateWeightFactory;
        private ICalculateRepWeight _calculateRepWeight;

        public CreateProgramLogFromTemplateCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService, ICalculateWeightFactory calculateWeightFactory, ICalculateRepWeight calculateRepWeight)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
            _calculateWeightFactory = calculateWeightFactory;
            _calculateRepWeight = calculateRepWeight;
        }

        public async Task<ProgramLogDTO> Handle(CreateProgramLogFromTemplateCommand request, CancellationToken cancellationToken)
        {
            await _programLogService.IsProgramLogAlreadyActive(request.ProgramLogDTO.StartDate, request.ProgramLogDTO.EndDate, request.UserId);

            var templateProgram = await _context.TemplateProgram
                .AsNoTracking()
                .Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramExtendedDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            if (templateProgram.NoOfDaysPerWeek != request.ProgramLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

            _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

            var programDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);
            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);

            programLog.ProgramLogWeeks = _programLogService.CreateProgramLogWeeksFromTemplate(templateProgram, request.ProgramLogDTO.StartDate, request.UserId); //create weeks based on template weeks

            var templateWeeks = templateProgram.TemplateWeeks.ToList();
            var counter = 0;

            //Apply exercises to days that have exercises on them
            foreach (var programLogWeek in programLog.ProgramLogWeeks)
            {
                var templateWeek = templateWeeks[counter++];
                programLogWeek.ProgramLogDays = _programLogService.CreateProgramLogDaysForWeekFromTemplate(programLogWeek, programDayOrder, templateWeek, request.UserId);
                var dayCounter = 0;
                foreach (var programLogDay in programLogWeek.ProgramLogDays)
                {
                    var templateDay = templateWeek.TemplateDays.ToList()[dayCounter++];
                    programLogDay.ProgramLogExercises = _programLogService.CreateProgramLogExercisesForTemplateDay(templateDay, request.ProgramLogDTO.WeightInputs, _calculateRepWeight, request.UserId);
                }
            }

            _context.ProgramLog.Add(programLog);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            if (modifiedRows <= 0) throw new ProgramLogAlreadyActiveException();

            var createdProgramLog = _mapper.Map<ProgramLogDTO>(programLog);
            return createdProgramLog;
        }
    }
}
