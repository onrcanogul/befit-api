using BeFit.Application.Common;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace BeFit.Infrastructure.Extensions
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => 404,
                BadRequestException => 400
            };

            var response = ServiceResponse<NoContent>.Failure(exception.Message, httpContext.Response.StatusCode);
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }

   
}
