using meow42_api.Abstracts;
using meow42_api.Dtos;
using meow42_api.Interfaces;

namespace meow42_api.Controllers;

public class JwtController : BaseController<LoginDto>
{
    private readonly ITokenManager _tokenManager;

    public JwtController(ITokenManager tokenManager, IHttpContextAccessor httpContext) : base(httpContext)
    {
        _tokenManager = tokenManager;
    }
    
    public async Task<IResult> GenerateToken()
    {
        return Results.Ok(_tokenManager.GenerateToken());
    }
}