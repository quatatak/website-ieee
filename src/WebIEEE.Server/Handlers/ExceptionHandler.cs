using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebIEEE.Contracts.Exceptions;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = CreateProblemDetails(exception);
        
        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ProblemDetails CreateProblemDetails(Exception ex)
    {
        ProblemDetails problemDetails = ex switch
        {
            NotFoundException => CreateProblemDetails(StatusCodes.Status404NotFound, "Not Found", ex.Message),
            CustomValidationException => CreateProblemDetails(StatusCodes.Status400BadRequest, "Validation error",
                ex.Message),
            _ => CreateProblemDetails(StatusCodes.Status500InternalServerError, "Internal server error", "An unexpected error occurred."),
        };

        if (ex is CustomValidationException validationException)
        {
            problemDetails.Extensions["errors"] = validationException.ValidationErrors;
        }
        
        return problemDetails;
    }

    private static ProblemDetails CreateProblemDetails(int statusCode, string title, string detail)
    {
        return new ProblemDetails()
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
        };
    }
}