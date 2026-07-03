using meow42_api.Interfaces;

namespace meow42_api.Middleware;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;
    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
        var tenantId = context.Request.Headers["tenant"].FirstOrDefault();
        var tenantDomain = context.Request.Host.Value;
        if (!string.IsNullOrEmpty(tenantId))
        {
            tenantService.SetTenant(tenantId);
        }

        if (!string.IsNullOrEmpty(tenantDomain))
        {
            tenantService.SetTenantDomain(tenantDomain);
        }

        await _next(context);
    }
}