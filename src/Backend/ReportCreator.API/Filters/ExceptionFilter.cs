using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReportCreator.Domain.DTOs;
using ReportCreator.Exception.ExceptionsBase;

namespace ReportCreator.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException validationException)
            {
                var errorMessages = validationException.GetErrorMessages();
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorDTO(errorMessages));
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorDTO("Internal Error server"));
            }
        }
    }
}
