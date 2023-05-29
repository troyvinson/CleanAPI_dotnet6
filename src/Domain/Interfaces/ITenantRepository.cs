using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> GetTenantsAsync(TenantParameters tenantParameters, bool trackChanges);
    Task<Tenant?> GetTenantByIdAsync(Guid tenantId, bool trackChanges);
    Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<Guid> ids, TenantParameters tenantParameters, bool trackChanges);
    void CreateTenant(Tenant tenant);
    void DeleteTenant(Tenant tenant);
}
