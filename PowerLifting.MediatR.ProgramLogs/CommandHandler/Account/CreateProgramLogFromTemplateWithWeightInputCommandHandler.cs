using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerLifting.Data.DTOs.ProgramLogs;
using PowerLifting.Data.DTOs.Templates;
using PowerLifting.Data.Entities;
using PowerLifting.Data.Entities.ProgramLogs;
using PowerLifting.Data.Exceptions.ProgramLogs;
using PowerLifting.Data.Exceptions.TemplatePrograms;
using PowerLifting.MediatR.ProgramLogs.Command.Account;
using PowerLifting.Service.ProgramLogs.Util;

namespace PowerLifting.MediatR.ProgramLogs.CommandHandler.Account
{
    public class CreateProgramLogFromTemplateWithWeightInputCommandHandler : IRequestHandler<CreateProgramLogFromTemplateWithWeightInputCommand, ProgramLogDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public CreateProgramLogFromTemplateWithWeightInputCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDTO> Handle(CreateProgramLogFromTemplateWithWeightInputCommand request, CancellationToken cancellationToken)
        {
            var doesExist = await _context.Set<ProgramLog>().AsNoTracking().AnyAsync(x => x.Active && x.UserId == request.UserId, cancellationToken: cancellationToken);
            if (doesExist) throw new ProgramLogAlreadyActiveException();

            var templateProgram = await _context.TemplateProgram.Where(x => x.TemplateProgramId == request.TemplateProgramId)
                .ProjectTo<TemplateProgramDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (templateProgram == null) throw new TemplateProgramNotFoundException();
            if (templateProgram.NoOfDaysPerWeek != request.ProgramLogDTO.DayCount) throw new ProgramDaysDoesNotMatchTemplateDaysException();

            templateProgram.TemplateWeeks = templateProgram.TemplateWeeks.OrderBy(x => x.WeekNo);
            request.ProgramLogDTO.ProgramDayOrder = ProgramLogHelper.CalculateDayOrder(request.ProgramLogDTO);

           // var liftingStats = await _context.LiftingStat.Where(x => x.UserId == request.UserId && x.RepRange == 1).AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

            var createdLog = new ProgramLogDTO
            {
                TemplateProgramId = templateProgram.TemplateProgramId,
                UserId = request.UserId,
                Monday = request.ProgramLogDTO.Monday,
                Tuesday = request.ProgramLogDTO.Tuesday,
                Wednesday = request.ProgramLogDTO.Wednesday,
                Thursday = request.ProgramLogDTO.Thursday,
                Friday = request.ProgramLogDTO.Friday,
                Saturday = request.ProgramLogDTO.Saturday,
                Sunday = request.ProgramLogDTO.Sunday,
                StartDate = request.ProgramLogDTO.StartDate,
                EndDate = request.ProgramLogDTO.StartDate.AddDays(templateProgram.NoOfWeeks * 7),
                NoOfWeeks = templateProgram.NoOfWeeks,
                Active = true,
               // ProgramLogWeeks = ProgramLogHelper.GenerateProgramWeekDates(request.ProgramLogDTO, templateProgram, request.ProgramLogDTO.WeightInputs, request.UserId)
            };

            //TODO FIX
            var programLog = _mapper.Map<ProgramLog>(createdLog);
            programLog.TemplateProgram = null;
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