using preponto_api.Dtos;
using preponto_api.Models;

namespace preponto_api.Extensions;

public static class MenuExtensions
{
    public static MenuDto ToDTO(this Menu menu, IEnumerable<Menu>? allMenus)
    {
        return new MenuDto
        {
            Id = menu.Id,
            Name = menu.Name,
            Label = menu.Name,
            Parameters = menu.Parameters,
            Route = menu.Route,
            ParentId = menu.ParentId,
            HasChildren = menu.HasChildren,
            Icon = menu.Icon,
            Order = menu.Order,
            Divisor = menu.Divisor,
            Type = menu.Type,
            Disabled = menu.Disabled,
            Template = menu.Template,
            Render = menu.Render,
            DeepChildren = allMenus
                .Where(m => m.ParentId == menu.Id)
                .OrderBy(m => m.Order)
                .Select(child => child.ToDTO(allMenus))
                .ToList()
        };
    }

    public static List<MenuDto> ToDtoList(this IEnumerable<Menu> menus)
    {
        return menus
            .Where(m => m.ParentId == null)
            .OrderBy(m => m.Order)
            .Select(m => m.ToDTO(menus))
            .ToList();
    }
}