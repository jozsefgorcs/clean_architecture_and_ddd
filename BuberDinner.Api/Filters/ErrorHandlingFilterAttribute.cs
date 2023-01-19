using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occured while processing your request. (filter)",
            Instance = context.HttpContext.Request.Path,
            Status = (int)HttpStatusCode.InternalServerError ,
            Detail = exception.Message
        };

        context.Result = new ObjectResult(problemDetails);


        context.ExceptionHandled = true;
    }
}