﻿using System.Linq;
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
using PowerBuddy.Data.Models.System;
using PowerBuddy.Util;

namespace PowerBuddy.App.Commands.Quotes
{
    public class UpdateQuoteCommand : IRequest<OneOf<bool, UserNotFound, QuoteNotFound>>
    {
        public QuoteDto QuoteDto { get; }
        public string UserId { get; }
        public UpdateQuoteCommand(QuoteDto quoteDto, string userId)
        {
            QuoteDto = quoteDto;
            UserId = userId;
        }
    }

    public class UpdateQuoteCommandValidator : AbstractValidator<UpdateQuoteCommand>
    {
        public UpdateQuoteCommandValidator()
        {
            RuleFor(x => x.QuoteDto).NotNull().WithMessage(ValidationConstants.NOT_NULL);
            RuleFor(x => x.UserId).NotEmpty().WithMessage(ValidationConstants.NOT_EMPTY);
        }
    }

    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand, OneOf<bool, UserNotFound, QuoteNotFound>>
    {
        private readonly PowerLiftingContext _context;
        private readonly IMapper _mapper;

        public UpdateQuoteCommandHandler(PowerLiftingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OneOf<bool, UserNotFound, QuoteNotFound>> Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
        {
            var isUserAdmin = await _context.User.AsNoTracking().AnyAsync(x => x.Id == request.UserId && x.MemberStatusId >= 2, cancellationToken: cancellationToken);

            if (!isUserAdmin)
            {
                return new UserNotFound();
            }

            var doesQuoteExist = await _context.Quote.Where(x => x.QuoteId == request.QuoteDto.QuoteId).AsNoTracking().AnyAsync(cancellationToken: cancellationToken);

            if (!doesQuoteExist)
            {
                return new QuoteNotFound();
            }

            var quote = _mapper.Map<Quote>(request.QuoteDto);
            _context.Quote.Update(quote);

            var modifiedRows = await _context.SaveChangesAsync(cancellationToken);
            return modifiedRows > 0;
        }
    }
}
