using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediaR.Quotes.Command.Account
{
    public class RequestQuoteCommand : IRequest<QuoteDTO>
    {
        public QuoteDTO QuoteDTO { get; }
        public string UserId { get; }
        public RequestQuoteCommand(QuoteDTO quoteDTO, string userId)
        {
            QuoteDTO = quoteDTO;
            UserId = userId;
        }
    }
}