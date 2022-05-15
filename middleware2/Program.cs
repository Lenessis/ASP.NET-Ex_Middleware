
using middleware2;
using UAParser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

/*app.UseUserAgent1Middleware();

app.UseCurrentBrowser1Middleware();*/

/*app.Use(async (context, next) =>
{
    //ua-parse -- doinstalowaæ ten pakiet
    var userAgent = context.Request.Headers["User-Agent"];
    var uaParser = Parser.GetDefault();
    ClientInfo c = uaParser.Parse(userAgent);

    await context.Response.WriteAsync("\n\nUA: " + userAgent.ToString() + "\n\nPrzegladarka: " + c + "\n");
    await next();
});*/

app.UseRedirect1Middleware();

app.MapRazorPages();

app.UseUserAgent1Middleware();

app.UseCurrentBrowser1Middleware();

app.Run(async (context) =>
{
    await context.Response.WriteAsync(
        "Run: ");
});

app.Run();
