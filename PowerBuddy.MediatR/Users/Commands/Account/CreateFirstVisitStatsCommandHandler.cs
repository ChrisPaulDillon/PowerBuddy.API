using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PowerBuddy.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Exceptions.Account;

namespace PowerBuddy.MediatR.Users.Commands.Account
{
    public class CreateFirstVisitStatsCommand : IRequest<bool>
    {
        public FirstVisitDTO FirstVisitDTO { get; }
        public string UserId { get; }

        public CreateFirstVisitStatsCommand(FirstVisitDTO firstVisitDTO, string userId)
        {
            FirstVisitDTO = firstVisitDTO;
            UserId = userId;
            new CreateFirstVisitStatsCommandValidator().ValidateAndThrow(this);
        }
    }

    public class CreateFirstVisitStatsCommandValidator : AbstractValidator<CreateFirstVisitStatsCommand>
    {
        public CreateFirstVisitStatsCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.FirstVisitDTO.GenderId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
        }
    }

    public class CreateFirstVisitStatsCommandHandler : IRequestHandler<CreateFirstVisitStatsCommand, bool>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateFirstVisitStatsCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateFirstVisitStatsCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId , cancellationToken: cancellationToken);
            if (user == null) throw new UserNotFoundException();

            //TODO fix
            user.GenderId = request.FirstVisitDTO.GenderId;
            //user.LiftingLevel = request.FirstVisitDTO.LiftingLevel;
            user.FirstVisit = true;

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}