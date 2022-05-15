using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UAParser;

namespace middleware2
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CurrentBrowser1Middleware
    {
        private readonly RequestDelegate _next;

        public CurrentBrowser1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);

            httpContext.Response.WriteAsync("Przegladarka: " + c + "\n\n");

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CurrentBrowser1MiddlewareExtensions
    {
        public static IApplicationBuilder UseCurrentBrowser1Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurrentBrowser1Middleware>();
        }
    }
}
