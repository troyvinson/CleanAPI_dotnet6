using Domain.Entities;

namespace Domain.Interfaces;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> GetTenantsAsync(bool trackChanges);
    Task<Tenant?> GetTenantByIdAsync(Guid tenantId, bool trackChanges);
    Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreateTenant(Tenant tenant);
    void DeleteTenant(Tenant tenant);
}
