using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.DTOs.Users;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Users
{
    public class CreateFirstVisitStatsCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public FirstVisitDTO FirstVisitDTO { get; }
        public string UserId { get; }

        public CreateFirstVisitStatsCommand(FirstVisitDTO firstVisitDTO, string userId)
        {
            FirstVisitDTO = firstVisitDTO;
            UserId = userId;
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

    public class CreateFirstVisitStatsCommandHandler : IRequestHandler<CreateFirstVisitStatsCommand, OneOf<bool, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;

        public CreateFirstVisitStatsCommandHandler(PowerLiftingContext context)
        {
            _context = context;
        }

        public async Task<OneOf<bool, UserNotFound>> Handle(CreateFirstVisitStatsCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == request.UserId , cancellationToken: cancellationToken);
            if (user == null)
            {
                return new UserNotFound();
            }

            //TODO fix
            user.GenderId = request.FirstVisitDTO.GenderId;
            //user.LiftingLevel = request.FirstVisitDTO.LiftingLevel;
            user.FirstVisit = true;

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}