using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediaR.Quotes.Command.Admin
{
    public class CreateQuoteCommand : IRequest<QuoteDTO>
    {
        public QuoteDTO QuoteDTO { get; }
        public string UserId { get; }
        public CreateQuoteCommand(QuoteDTO quoteDTO, string userId)
        {
            QuoteDTO = quoteDTO;
            UserId = userId;
        }
    }
}