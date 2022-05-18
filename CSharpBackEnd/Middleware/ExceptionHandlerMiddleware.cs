using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CSharpBackEnd.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ArgumentNullException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var zeroValue = 0;
                context.Response.Headers.Add("X-Total-Count", zeroValue.ToString());
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var minusValue = -1;
                context.Response.Headers.Add("X-Total-Count", minusValue.ToString());
            }
        }

    }
}
