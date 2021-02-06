using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using PowerBuddy.Data.Context;
using PowerBuddy.Data.Dtos.System;
using PowerBuddy.Data.Entities;
using PowerBuddy.Data.Models.Account;

namespace PowerBuddy.App.Commands.Quotes
{
    public class CreateQuoteCommand : IRequest<OneOf<QuoteDto, UserNotFound>>
    {
        public QuoteDto QuoteDto { get; }
        public string UserId { get; }
        public CreateQuoteCommand(QuoteDto quoteDto, string userId)
        {
            QuoteDto = quoteDto;
            UserId = userId;
        }
    }

    public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
    {
        public CreateQuoteCommandValidator()
        {
            RuleFor(x => x.QuoteDto).NotNull().WithMessage("'{PropertyName}' cannot be empty.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("'{PropertyName}' cannot be empty.");
        }
    }

    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, OneOf<QuoteDto, UserNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;
        public CreateQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<QuoteDto, UserNotFound>> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin)
            {
                return new UserNotFound();
            }

            var quoteEntity = _mapper.Map<Quote>(request.QuoteDto); //TODO validate request
            await _context.Quote.AddAsync(quoteEntity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return request.QuoteDto;
        }
    }
}
