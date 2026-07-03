using preponto_api.Controllers;

namespace preponto_api.Infras;

public static class Routes
{
    public static void AddRoutes(this WebApplication app)
    {
        var apiV1 = app.MapGroup("api/v1/");

        apiV1.MapPost("jwt", (JwtController controller) => controller.GenerateToken());
        
        apiV1.MapGet("menu", (MenuController controller) => controller.Index());
        apiV1.MapGet("menu/{id:int}", (MenuController controller, int id) => controller.Show(id));
        apiV1.MapPost("menu", (MenuController controller) => controller.Create());
        apiV1.MapPut("menu/{id:int}",  (MenuController controller, int id) => controller.Edit(id));
        apiV1.MapDelete("menu/{id:int}",  (MenuController controller, int id) => controller.Delete(id));
        apiV1.MapGet("nestedmenu", (MenuController controller) => controller.GetNestedMenusAsync());
    }
}