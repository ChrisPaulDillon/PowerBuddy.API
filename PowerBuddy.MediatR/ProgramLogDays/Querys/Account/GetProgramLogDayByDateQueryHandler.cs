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
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogDays.Querys.Account
{
    public class GetProgramLogDayByDateQuery : IRequest<ProgramLogDayDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetProgramLogDayByDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
            new GetProgramLogDayByDateQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogDayByDateQueryValidator : AbstractValidator<GetProgramLogDayByDateQuery>
    {
        public GetProgramLogDayByDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' must not be empty");
        }
    }

    public class GetProgramLogDayByDateQueryHandler : IRequestHandler<GetProgramLogDayByDateQuery, ProgramLogDayDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public GetProgramLogDayByDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogDayDTO> Handle(GetProgramLogDayByDateQuery request, CancellationToken cancellationToken)
        {
            var programLogDayDTO = await _context.Set<ProgramLogDay>().Where(x => x.UserId == request.UserId && DateTime.Compare(request.Date.Date, x.Date.Date) == 0)
                .ProjectTo<ProgramLogDayDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogDayDTO == null) throw new ProgramLogDayNotFoundException();
            return programLogDayDTO;
        }
    }
}
