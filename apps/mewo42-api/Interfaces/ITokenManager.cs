namespace preponto_api.Interfaces;

public interface ITokenManager
{
    string GenerateToken();
    string GenerateRefreshToken();
    Task<bool> ValidateTokenAsync(string token); 
}