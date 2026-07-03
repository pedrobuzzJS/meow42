using System.Text.Json;

namespace preponto_api.Abstracts;

public abstract class BaseController<TModel>
{
    protected readonly IHttpContextAccessor _httpContextAccessor;

    public BaseController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TModel> GetParserdJsonAsync()
    {
        using var reader = new StreamReader(_httpContextAccessor.HttpContext!.Request.Body);
        var body = await reader.ReadToEndAsync();

        var parsedBody = JsonSerializer.Deserialize<TModel>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        return parsedBody;
    }
}