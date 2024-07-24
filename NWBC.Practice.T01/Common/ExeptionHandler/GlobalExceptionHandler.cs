using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Common.ExeptionHandler;

public class GlobalExceptionHandler(ILogger logger) : IExceptionHandler
{
    private ILogger _logger = logger;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        Log.Error($"An unexpected exception :{exception.Message}");
        
        var problemDetails = new ProblemDetails
        {
            Detail = exception.Message,
            Type = exception.GetType().Name
        };

        switch (exception)
        {
            case BadHttpRequestException:
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Title = exception.GetType().Name;
                break;
            
            default:
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                problemDetails.Title = "Internal server error detected.";
                break;
        }

        httpContext.Response.StatusCode = (int)problemDetails.Status;
        
        await httpContext
            .Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}