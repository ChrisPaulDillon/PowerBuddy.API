using System;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PowerBuddy.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log issues and handle exception response

            if (exception.GetType() == typeof(ValidationException))
            {
                var code = HttpStatusCode.BadRequest;
                var result = JsonConvert.SerializeObject(((ValidationException) exception).Errors);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) code;
                return context.Response.WriteAsync(result);

            }
            else
            {
                var code = HttpStatusCode.InternalServerError;
                var result = JsonConvert.SerializeObject(new {isSuccess = false, error = exception.Message});
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) code;
                return context.Response.WriteAsync(result);
            }
        }
    }
}