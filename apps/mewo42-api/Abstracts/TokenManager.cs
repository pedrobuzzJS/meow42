using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using preponto_api.Helpers;
using preponto_api.Interfaces;

namespace preponto_api.Abstracts;

public class TokenManager : ITokenManager
{
    private readonly IConfiguration _configuration;
    private readonly ITenantService _tenantService;

    public TokenManager(IConfiguration configuration, ITenantService tenantService)
    {
        _configuration = configuration;
        _tenantService = tenantService;
    }

    public string GenerateToken()
    {
        var JwtSettings = _configuration.GetSection("JwtSettings");
        var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["SecretKey"] ?? string.Empty));

        var Claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, "Pedro"),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, "Admin"),
            new("CompanyId", _tenantService.TenantDomain)
        };
        var expirationTimeInMinutes = JwtSettings.GetValue<int>("ExpirationTimeInMinutes");

        var token = new JwtSecurityToken(
            issuer: JwtSettings.GetValue<string>("Issuer"),
            audience: JwtSettings.GetValue<string>("Audience"),
            claims: Claims,
            expires: DateTime.UtcNow.AddSeconds(expirationTimeInMinutes),
            signingCredentials: new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public string GenerateRefreshToken()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings["SecretKey"] ?? string.Empty));
        
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Name, "Pedro"),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim("CustomData", "Qualquer valor aqui"),
        };
        
        var tempoExpiracaoInMinutes = jwtSettings.GetValue<int>("RefreshExpirationTimeInMinutes");
        
        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetValue<string>("Issuer"),
            audience: jwtSettings.GetValue<string>("Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tempoExpiracaoInMinutes),
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<bool> ValidateTokenAsync(string token)
    {
        if(string.IsNullOrWhiteSpace(token))
            return false;
        
        var tokenParameters = TokenHelpers.GetTokenValidationParameters(_configuration);
        var validTokenResult = await new JwtSecurityTokenHandler().ValidateTokenAsync(token, tokenParameters);

        if (!validTokenResult.IsValid)
            return false;
        
        var userName = validTokenResult
            .Claims.FirstOrDefault(c => c.Key == ClaimTypes.NameIdentifier).Value as string;

        return true;
    }
}