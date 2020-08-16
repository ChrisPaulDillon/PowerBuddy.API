using MediatR;
using PowerLifting.Data.DTOs.System;
using System.Collections.Generic;

namespace PowerLifting.MediaR.Quotes.Query.Public
{
    public class GetAllQuotesQuery : IRequest<IEnumerable<QuoteDTO>>
    {
        public GetAllQuotesQuery()
        {
        }
    }
}