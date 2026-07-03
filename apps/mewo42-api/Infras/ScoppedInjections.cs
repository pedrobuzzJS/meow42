using meow42_api.Controllers;
using meow42_api.Services;

namespace meow42_api.Infras;

public static class ScoppedInjections
{
    public static void AddScoppedInjections(this IServiceCollection app)
    {
        app.AddScoped<MenuController>();
        app.AddScoped<MenuService>();
    }
}