using System.Diagnostics;

namespace preponto_api.Middleware;

public class GlobalErrorMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = e.Message,
                Trace = e.Demystify().StackTrace,
            });
        }
    }
}