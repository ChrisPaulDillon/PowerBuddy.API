using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediaR.Quotes.Command.Admin
{
    public class DeleteQuoteCommand : IRequest<bool>
    {
        public int QuoteId { get; }
        public string UserId { get; }
        public DeleteQuoteCommand(int quoteId, string userId)
        {
            QuoteId = quoteId;
            UserId = userId;
        }
    }
}