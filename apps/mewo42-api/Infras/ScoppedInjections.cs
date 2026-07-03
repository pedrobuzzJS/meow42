using preponto_api.Controllers;
using preponto_api.Services;

namespace preponto_api.Infras;

public static class ScoppedInjections
{
    public static void AddScoppedInjections(this IServiceCollection app)
    {
        app.AddScoped<MenuController>();
        app.AddScoped<MenuService>();
    }
}