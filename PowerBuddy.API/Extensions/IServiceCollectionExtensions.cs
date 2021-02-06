
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using PowerBuddy.API.Middleware;

namespace PowerBuddy.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
