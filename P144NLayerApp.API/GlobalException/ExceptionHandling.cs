using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace P144NLayerApp.API.GlobalException
{
    public class ExceptionHandling : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Log.Error(exception.Message);
            httpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
            httpContext.Response.WriteAsync("Any problem occured!");
            return ValueTask.FromResult(true);
        }
    }
}
