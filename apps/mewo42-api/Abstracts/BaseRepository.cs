using Microsoft.EntityFrameworkCore;
using meow42_api.Data;

namespace meow42_api.Abstracts;

public class BaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<int> StoreAsync()
    {
        return await _context.SaveChangesAsync();
    }
}