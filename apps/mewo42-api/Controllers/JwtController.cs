using preponto_api.Abstracts;
using preponto_api.Dtos;
using preponto_api.Interfaces;

namespace preponto_api.Controllers;

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