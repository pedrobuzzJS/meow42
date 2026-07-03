using preponto_api.Interfaces;

namespace preponto_api.Services;

public class TenantService : ITenantService
{
    public string TenantId { get; private set; }
    public string TenantDomain { get; private set; }

    public void SetTenantDomain(string tenantDomain)
    {
        TenantDomain = tenantDomain;
    }
    public void SetTenant(string tenantId)
    {
        TenantId = tenantId;
    }
}