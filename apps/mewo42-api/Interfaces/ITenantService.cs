namespace preponto_api.Interfaces;

public interface ITenantService
{
    string TenantId { get; }
    string TenantDomain { get; }
    void SetTenant(string tenantId);
    void SetTenantDomain(string tenantDomain);
}