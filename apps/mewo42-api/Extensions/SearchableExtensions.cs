using Microsoft.EntityFrameworkCore;
using meow42_api.Abstracts;

namespace meow42_api.Extensions;

public static class SearchableExtensions
{
    public static async Task<PagedResponse<T>> ToPagedResponse<T>(this IQueryable<T> query, int page, int perPage, string baseUrl)
    {
        var total = await query.CountAsync();
        var lastPage = (int)Math.Ceiling((double)total / perPage);
        var skip = (page - 1) * perPage; 
        query = query.OrderByDescending(e => EF.Property<object>(e, "Id"));
        var items = await query.Skip(skip).Take(perPage).ToListAsync();

        return new PagedResponse<T>
        {
            CurrentPage = page,
            FirstPageUrl = $"{baseUrl}?page=1&perPage={perPage}",
            LastPageUrl = $"{baseUrl}?page={lastPage}&perPage={perPage}",
            NextPageUrl = page < lastPage ? $"{baseUrl}?page={page + 1}&perPage={perPage}" : null,
            LastPage = lastPage,
            Path = baseUrl,
            PerPage = perPage,
            PreviousPageUrl = page > 1 ? $"{baseUrl}?page={page - 1}&perPage={perPage}" : null,
            From = total == 0 ? 0 : skip + 1,
            To = Math.Min(skip + perPage, total),
            Total = total,
            Data = items
        };
    } 
}