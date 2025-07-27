using System.Text.Json;
using App.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace App.Middleware;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public required string Error { get; set; }
}

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken = default)
    {
        var errorResponse = new ErrorResponse
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Error = "An unexpected error occurred. Please try again later."
        };

        switch (exception)
        {
            case EntityNotFoundException notFoundException:
                errorResponse.StatusCode = StatusCodes.Status404NotFound;
                errorResponse.Error = notFoundException.Message;
                break;
            case BusinessRuleViolationException businessRuleViolationException:
                errorResponse.StatusCode = StatusCodes.Status400BadRequest;
                errorResponse.Error = businessRuleViolationException.Message;
                break;
            default:
                _logger.LogError(exception, "An unexpected error occurred");
                break;
        }

        context.Response.StatusCode = errorResponse.StatusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        return true;
    }

}