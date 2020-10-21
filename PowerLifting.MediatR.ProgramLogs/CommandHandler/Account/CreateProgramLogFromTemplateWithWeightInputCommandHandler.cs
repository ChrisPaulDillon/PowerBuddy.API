using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Service.ProgramLogs;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class CreateProgramLogFromTemplateWithWeightInputCommandHandler : IRequestHandler<CreateProgramLogFromTemplateWithWeightInputCommand, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IProgramLogService _programLogService;

        public CreateProgramLogFromTemplateWithWeightInputCommandHandler(PowerLiftingContext context, IMapper mapper, IProgramLogService programLogService)
        {
            _context = context;
            _mapper = mapper;
            _programLogService = programLogService;
        }

        public async Task<ProgramLogDTO> Handle(CreateProgramLogFromTemplateWithWeightInputCommand request, CancellationToken cancellationToken)
        {
            await _programLogService.IsProgramLogAlreadyActive(request.UserId);

            var templateProgram = await _context.TemplateProgram.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            if (templateProgram.NoOfDaysPerWeek != request.ProgramLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);

            // var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.RepRange == 1).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

            request.ProgramLogDTO.EndDate = request.ProgramLogDTO.StartDate.AddDays(templateProgram.NoOfWeeks * 7);
            request.ProgramLogDTO.NoOfWeeks = templateProgram.NoOfWeeks;
            //request.ProgramLogDTO.ProgramLogWeeks = _programLogService.CreateProgramLogWeeksFromTemplate(templateProgram, request.ProgramLogDTO.StartDate, request.UserId); //create weeks based on template weeks
            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);


            //TODO FIX
            var programLog = _mapper.Map<ProgramLog>(request.ProgramLogDTO);
            _context.ProgramLog.Add(programLog);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            if (modifiedRows > 0)
            {
                var createdProgramLog = _mapper.Map<ProgramLogDTO>(programLog);
                return createdProgramLog;
            }

            throw new ProgramLogAlreadyActiveException();
        }
    }
}