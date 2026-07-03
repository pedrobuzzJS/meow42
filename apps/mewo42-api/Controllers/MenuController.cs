using preponto_api.Abstracts;
using preponto_api.Models;
using preponto_api.Services;

namespace preponto_api.Controllers;

public class MenuController : BaseController<Menu>
{
    private readonly MenuService _menuService;

    public MenuController(MenuService service, IHttpContextAccessor httpContext) : base(httpContext)
    {
        _menuService = service;
    }
    public async Task<IResult> Index()
    {
        return Results.Ok(await _menuService.GetAllAsync(_httpContextAccessor));
    }
    public async Task<IResult> Create()
    {
        return Results.Ok(await _menuService.Store(await GetParserdJsonAsync()));
    }
    public async Task<IResult> Show(int id)
    {
        var menu = await _menuService.ShowAsync(id);
        return menu != null ? Results.Ok(menu) : Results.NotFound();
    }
    public async Task<IResult> Edit(int id)
    {
        return Results.Ok(await _menuService.Edit(await GetParserdJsonAsync()));
    }
    public async Task<IResult> Delete(int id)
    {
        await _menuService.Delete([id]);
        return Results.NotFound();
    }
    public async Task<IResult> GetNestedMenusAsync()
    {
        return Results.Ok(await _menuService.GetNestedMenusAsync());
    }
}