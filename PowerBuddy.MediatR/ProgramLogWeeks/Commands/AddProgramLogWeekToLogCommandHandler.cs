using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;
using PowerBuddy.Data.Factories;

namespace PowerBuddy.MediatR.ProgramLogWeeks.Commands
{
    public class AddProgramLogWeekToLogCommand : IRequest<ProgramLogWeekExtendedDTO>
    {
        public int ProgramLogId { get; }
        public string UserId { get; }

        public AddProgramLogWeekToLogCommand(int programLogId, string userId)
        {
            ProgramLogId = programLogId;
            UserId = userId;
            new AddProgramLogWeekToLogCommandValidator().ValidateAndThrow(this);
        }
    }

    public class AddProgramLogWeekToLogCommandValidator : AbstractValidator<AddProgramLogWeekToLogCommand>
    {
        public AddProgramLogWeekToLogCommandValidator()
        {
            RuleFor(x => x.ProgramLogId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than 0.");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class AddProgramLogWeekToLogCommandHandler : IRequestHandler<AddProgramLogWeekToLogCommand, ProgramLogWeekExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        private readonly IDTOFactory _dtoFactory;

        public AddProgramLogWeekToLogCommandHandler(PowerLiftingContext context, IMapper mapper, IDTOFactory dtoFactory)
        {
            _context = context;
            _mapper = mapper;
            _dtoFactory = dtoFactory;
        }

        public async Task<ProgramLogWeekExtendedDTO> Handle(AddProgramLogWeekToLogCommand request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog
                .Where(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId)
                .Include(x => x.ProgramLogWeeks)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLog == null) throw new ProgramLogNotFoundException();

            var lastProgramWeek = programLog.ProgramLogWeeks.OrderByDescending(x => x.WeekNo).FirstOrDefault();

            var weekStartDate = lastProgramWeek.EndDate.AddDays(1);
            var programLogWeek = _dtoFactory.CreateProgramLogWeekDTO(weekStartDate, lastProgramWeek.WeekNo + 1, request.UserId);

            programLogWeek.ProgramLogId = lastProgramWeek.ProgramLogId;

            var programLogWeekEntity = _mapper.Map<ProgramLogWeek>(programLogWeek);
            _context.ProgramLogWeek.Add(programLogWeekEntity);

            programLog.NoOfWeeks++;
            programLog.EndDate = programLog.EndDate.AddDays(7);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProgramLogWeekExtendedDTO>(programLogWeekEntity);

        }
    }
}
