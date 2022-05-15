using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace middleware2
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserAgent1Middleware
    {
        private readonly RequestDelegate _next;

        public UserAgent1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            httpContext.Response.WriteAsync("User-Agent: " + userAgent + "\n\n");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserAgent1MiddlewareExtensions
    {
        public static IApplicationBuilder UseUserAgent1Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserAgent1Middleware>();
        }
    }
}
