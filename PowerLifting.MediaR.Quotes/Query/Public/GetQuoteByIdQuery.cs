using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using PowerLifting.Data.DTOs.System;

namespace PowerLifting.MediaR.Quotes.Query.Public
{
    public class GetQuoteByIdQuery : IRequest<QuoteDTO>
    {
        public int QuoteId { get; }
        public GetQuoteByIdQuery(int quoteId)
        {
            QuoteId = quoteId;
        }
    }
}