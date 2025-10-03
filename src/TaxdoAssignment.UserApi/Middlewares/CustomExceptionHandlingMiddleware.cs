using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.UserApi;

public class CustomExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        when (ex is BusinessRuleValidationException || ex is ValidationException)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Validation exception occured",
                Detail = ex.Message,
                Status = StatusCodes.Status400BadRequest,
                Instance = context.Request.Path,
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Unexpected server error occured",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.Request.Path,
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            var json = JsonSerializer.Serialize(problemDetails);
            await context.Response.WriteAsync(json);
        }
    }
}
