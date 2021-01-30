using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerBuddy.MediatR.Queries.Authentication;
using PowerBuddy.MediatR.Queries.Users;

namespace PowerBuddy.MediatR.Queries.Quotes.Extensions
{
    public static class QuoteServicesConfiguration
    {
        public static IServiceCollection AddQuoteMediatrHandlers(this IServiceCollection services)
        {
            // QueryHandler Registration
            services.AddMediatR(typeof(GetAllQuotesQueryHandler));
            services.AddMediatR(typeof(GetQuoteByIdQueryHandler));
            return services;
        }
    }
}
