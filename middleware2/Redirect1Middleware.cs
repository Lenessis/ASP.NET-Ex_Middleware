using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UAParser;

namespace middleware2
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Redirect1Middleware
    {
        private readonly RequestDelegate _next;

        public Redirect1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var userAgent = httpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);

            string browser = c.ToString();

            if (browser.Contains("Edge") || browser.Contains("IE") || browser.Contains("EdgeChromium"))

                httpContext.Response.Redirect("https://www.mozilla.org/pl/firefox/new/");
            
             return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Redirect1MiddlewareExtensions
    {
        public static IApplicationBuilder UseRedirect1Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Redirect1Middleware>();
        }
    }
}
