using MongoDB.Bson.IO;
using sharurl_api.DTOs;
using sharurl_api.Exceptions;
using System.Net;
using System.Text.Json;

namespace sharurl_api.Middlewares
{
    public class ExceptionHandlerMiddelware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is CodeNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var result = JsonSerializer.Serialize(new ExceptionDTO("Code not found"));
                return context.Response.WriteAsync(result);
            }

            if (ex is UpdateFailedException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new ExceptionDTO("Failed to update"));
                return context.Response.WriteAsync(result);
            }

            if (ex is DeleteFailedException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new ExceptionDTO("Failed to delete"));
                return context.Response.WriteAsync(result);
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
            var defaultResult = JsonSerializer.Serialize(new ExceptionDTO("An error occurred."));
            return context.Response.WriteAsync(defaultResult);
        }
    }
}
