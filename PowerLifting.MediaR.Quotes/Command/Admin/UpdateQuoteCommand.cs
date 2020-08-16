using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediaR.Quotes.Command.Admin
{
    public class UpdateQuoteCommand : IRequest<bool>
    {
        public QuoteDTO QuoteDTO { get; }
        public string UserId { get; }
        public UpdateQuoteCommand(QuoteDTO quoteDTO, string userId)
        {
            QuoteDTO = quoteDTO;
            UserId = userId;
        }
    }
}