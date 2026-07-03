using Microsoft.EntityFrameworkCore;
using preponto_api.Data;

namespace preponto_api.Abstracts;

public abstract class BaseService<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _repository;
    protected readonly AppDbContext _context;
    
    public BaseService(AppDbContext context)
    {
        _repository = context.Set<TEntity>();
        _context = context;
    }

    public virtual async Task<PagedResponse<TEntity>> GetAllAsync(IHttpContextAccessor _httpContextAccessor = null)
    {
        var page = 1;
        var perPage = 20;
        
        var query = _httpContextAccessor?.HttpContext?.Request?.Query;

        if (query != null)
        {
            if (query.TryGetValue("page", out var pageValue) && int.TryParse(pageValue, out var p))
                page = p;

            if (query.TryGetValue("perPage", out var perPageValue) && int.TryParse(perPageValue, out var pp))
            {
                if (pp > 100)
                {
                    return new PagedResponse<TEntity>()
                    {
                        FirstPageUrl = $"{_httpContextAccessor?.HttpContext?.Request?.Host.Value}{_httpContextAccessor?.HttpContext?.Request?.Path.Value}?page=1&perPage={perPage}",
                        ErrorMessage = "A quantidade de itens por consulta não pode ser maior do que 100 itens"
                    };
                }
                perPage = pp;
            }
        }

        return await _repository
            .AsNoTracking()
            .AsQueryable()
            .ToPagedResponse(
                page,
                perPage,
                $"{_httpContextAccessor?.HttpContext?.Request?.Host.Value}{_httpContextAccessor?.HttpContext?.Request?.Path.Value}"
            );
    }

    // public virtual async Task<List<TEntity>> ShowAsync(int id)
    // {
    //     
    // }

    public virtual async Task<TEntity> ShowItemAsync(int id)
    {
        return await _repository.FindAsync(id);
    }
    
    public virtual async Task<int> Edit(TEntity entity)
    {
        _repository.Update(entity);
        return await _context.SaveChangesAsync();
    }
    
    public virtual async Task<int> Store(TEntity entity)
    {
        await _repository.AddAsync(entity);
        return await _context.SaveChangesAsync(); 
    }

    public virtual async Task<int> Delete(int[] ids)
    {
        return await _repository
            .Where(e => ids.Contains(EF.Property<int>(e, "Id")))
            .ExecuteDeleteAsync();
    }
}