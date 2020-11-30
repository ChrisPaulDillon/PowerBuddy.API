using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.ProgramLogs;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Exceptions.ProgramLogs;

namespace PowerBuddy.MediatR.ProgramLogWeeks.Querys.Account
{
    public class GetProgramLogWeekBetweenDateQuery : IRequest<ProgramLogWeekExtendedDTO>
    {
        public DateTime Date { get; }
        public string UserId { get; }

        public GetProgramLogWeekBetweenDateQuery(DateTime date, string userId)
        {
            Date = date;
            UserId = userId;
            new GetProgramLogWeekBetweenDateQueryValidator().ValidateAndThrow(this);
        }
    }

    public class GetProgramLogWeekBetweenDateQueryValidator : AbstractValidator<GetProgramLogWeekBetweenDateQuery>
    {
        public GetProgramLogWeekBetweenDateQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class GetProgramLogWeekBetweenDateQueryHandler : IRequestHandler<GetProgramLogWeekBetweenDateQuery, ProgramLogWeekExtendedDTO>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public GetProgramLogWeekBetweenDateQueryHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProgramLogWeekExtendedDTO> Handle(GetProgramLogWeekBetweenDateQuery request, CancellationToken cancellationToken)
        {
            var programLogWeek = await _context.ProgramLogWeek
                                    .AsNoTracking()
                                    .Where(x => x.UserId == request.UserId &&
                                                x.StartDate.Date <= request.Date.Date &&
                                                x.EndDate.Date >= request.Date.Date)
                                    .ProjectTo<ProgramLogWeekExtendedDTO>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (programLogWeek == null) throw new ProgramLogWeekNotFoundException();
            return programLogWeek;
        }
    }
}
