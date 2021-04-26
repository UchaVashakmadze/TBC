using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Common.Shared.Exceptions;
using Common.Shared.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace TBC.API.Infrastructure.Midlewares
{
    /// <summary>
    /// Exception Handling Middleware
    /// </summary>
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            if (exception is NotFoundException)
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            else if (exception is ValidationException)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            else
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Error Occured at {DateTime.UtcNow.ToShortDateString()} {DateTime.UtcNow.ToShortTimeString()}\n");
            if (!string.IsNullOrEmpty(exception.Message))
            {
                stringBuilder.Append("Message: ");
                stringBuilder.Append(exception.Message);
                stringBuilder.Append("\n");
            }
            if (exception.InnerException != null && !string.IsNullOrEmpty(exception.InnerException.Message))
            {
                stringBuilder.Append("Inner Exception: ");
                stringBuilder.Append(exception.InnerException.Message);
                stringBuilder.Append("\n");
            }
            if (exception.StackTrace != null)
            {
                stringBuilder.Append("Stack Trace: ");
                stringBuilder.Append(exception.StackTrace);
            }
            _logger.LogError(stringBuilder.ToString());

            if (exception is CustomException)
                return context.Response.WriteAsync($"\"{exception.Message}\"");
            else
                return context.Response.WriteAsync($"\"{ErrorMessageResource.ErrorOccured}\"");
        }
    }
}
