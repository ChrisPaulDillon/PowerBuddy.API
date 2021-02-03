using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PowerBuddy.App.Queries.Quotes.Extensions
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
