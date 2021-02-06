using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.Users;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Users
{
    public class CreateFirstVisitStatsCommand : IRequest<OneOf<bool, UserNotFound>>
    {
        public FirstVisitDto FirstVisitDto { get; }
        public string UserId { get; }

        public CreateFirstVisitStatsCommand(FirstVisitDto firstVisitDto, string userId)
        {
            FirstVisitDto = firstVisitDto;
            UserId = userId;
        }
    }

    public class CreateFirstVisitStatsCommandValidator : AbstractValidator<CreateFirstVisitStatsCommand>
    {
        public CreateFirstVisitStatsCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.FirstVisitDto.GenderId).GreaterThan(0).WithMessage("'{PropertyName}' must be greater than {ComparisonValue}.");
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
            user.GenderId = request.FirstVisitDto.GenderId;
            //user.LiftingLevel = request.FirstVisitDto.LiftingLevel;
            user.FirstVisit = true;

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}