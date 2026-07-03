using Microsoft.EntityFrameworkCore;
using meow42_api.Abstracts;
using meow42_api.Data;
using meow42_api.Dtos;
using meow42_api.Models;

namespace meow42_api.Services;

public class MenuService : BaseService<Menu>
{
    public MenuService(AppDbContext context) : base(context) {}
    
    public async Task<List<MenuDto>> GetNestedMenusAsync()
    {
        var menus = await _repository.AsNoTracking().ToListAsync();
        return menus.ToDtoList();
    }    
    
    public async Task<Menu?> ShowAsync(int id)
    {
        return await _repository.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> Delete(int id)
    {
        var menu = await _repository.FirstAsync(x => x.Id == id);
        if (menu == null)
            return false;
        _repository.Remove(menu);
        await _context.SaveChangesAsync();
        return true;
    }
}