using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ApiServer.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    switch (contextFeature.Error)
                    {
                        case NotFoundException:
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                            await WriteErrorDetails(context, contextFeature.Error.Message, context.Response.StatusCode);
                            break;
                        case BadRequestException:
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await WriteErrorDetails(context, contextFeature.Error.Message, context.Response.StatusCode);
                            break;
                        case ValidationAppException exception:
                            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new { exception.Errors }));
                            break;
                        default:
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                            await WriteErrorDetails(context, contextFeature.Error.Message, context.Response.StatusCode);
                            break;
                    }

                    logger.LogError($"An error occurred: {contextFeature.Error}");

                }
            });
        });
    }

    private static async Task WriteErrorDetails(HttpContext context, string message, int statusCode)
    {
        var response = new ErrorDetails
        {
            StatusCode = statusCode,
            Message = message,
            Path = context.Request.Path.Value ?? string.Empty,
            Method = context!.Request.Method ?? string.Empty
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
