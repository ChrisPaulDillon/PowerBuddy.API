using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogDays.Querys.Account
{
    public class GetProgramSpecificDayByDateQuery : IRequest<ProgramLogDayDTO>
    {
        public DateTime Date { get; }
        public int ProgramLogId { get; }
        public string UserId { get; }

        public GetProgramSpecificDayByDateQuery(DateTime date, int programLogId, string userId)
        {
            Date = date;
            ProgramLogId = programLogId;
            UserId = userId;
            new GetProgramSpecificDayByDateQueryValidator().ValidateAndThrow(this);
        }
    }

    internal class GetProgramSpecificDayByDateQueryValidator : AbstractValidator<GetProgramSpecificDayByDateQuery>
    {
        public GetProgramSpecificDayByDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.ProgramLogId).GreaterThan(0).WithMessage("'{PropertyName}' must not be greater than 0");
        }
    }

    internal class GetProgramSpecificDayByDateQueryHandler : IRequestHandler<GetProgramSpecificDayByDateQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramSpecificDayByDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramSpecificDayByDateQuery request, CancellationToken cancellationToken)
        {
            var programLog = await _context.ProgramLog.AsNoTracking().ProjectTo<ProgramLogDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.ProgramLogId == request.ProgramLogId && x.UserId == request.UserId);

            if (programLog == null) throw new ProgramLogNotFoundException();

            var programLogWeek = programLog.ProgramLogWeeks.FirstOrDefault(x => request.Date.Date >= x.StartDate.Date &&
                                                                                request.Date.Date <= x.EndDate.Date);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();

            var programLogDay = programLogWeek.ProgramLogDays.FirstOrDefault(x => x.UserId == request.UserId
                                                                                  && DateTime.Compare(request.Date.Date,
                                                                                      x.Date.Date) == 0);

            if (programLogDay == null) throw new ProgramLogDayNotFoundException();
            return programLogDay;
        }
    }
}
