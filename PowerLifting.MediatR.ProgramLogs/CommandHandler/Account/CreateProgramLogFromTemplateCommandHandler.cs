using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.LiftingStats;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Factories;
using PowerLifting.Service.ProgramLogs.Strategies;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
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
            var doesExist = await _context.ProgramLog
                .AsNoTracking()
                .AnyAsync(x => x.Active && x.UserId == request.UserId, cancellationToken: cancellationToken);

            if (doesExist) throw new ProgramLogAlreadyActiveException();

            var templateProgram = await _context.TemplateProgram
                .Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            if (templateProgram.NoOfDaysPerWeek != request.ProgramLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

            _calculateRepWeight = _calculateWeightFactory.Create(templateProgram.WeightProgressionType);

            request.ProgramLogDTO.EndDate = request.ProgramLogDTO.StartDate.AddDays(templateProgram.NoOfWeeks * 7);
            request.ProgramLogDTO.NoOfWeeks = templateProgram.NoOfWeeks;
            request.ProgramLogDTO.ProgramLogWeeks = _programLogService.CreateProgramLogWeeksFromTemplate(templateProgram, request.ProgramLogDTO.StartDate, request.UserId); //create weeks based on template weeks
            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);

            var liftingStats = await _context.LiftingStat
                .Where(x => x.UserId == request.UserId && x.RepRange == 1)
                .ProjectTo<LiftingStatDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

            var templateWeeks = templateProgram.TemplateWeeks.ToList();
            var counter = 0;

            foreach (var programLogWeek in request.ProgramLogDTO.ProgramLogWeeks)
            {
                var templateWeek = templateWeeks[counter++];
                programLogWeek.ProgramLogDays = _programLogService.CreateProgramLogDaysForWeekFromTemplate(programLogWeek, request.ProgramLogDTO.ProgramDayOrder, templateWeek, request.UserId);
                var dayCounter = 0;
                foreach (var programLogDay in programLogWeek.ProgramLogDays)
                {
                    var templateDay = templateWeek.TemplateDays.ToList()[dayCounter++];
                    programLogDay.ProgramLogExercises = _programLogService.CreateProgramLogExercisesForTemplateDay(templateDay, liftingStats, _calculateRepWeight);
                }
            }

            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Add(programLog);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            if (modifiedRows <= 0) throw new ProgramLogAlreadyActiveException();

            var createdProgramLog = _mapper.Map<ProgramLogDTO>(programLog);
            return createdProgramLog;
        }
    }
}
