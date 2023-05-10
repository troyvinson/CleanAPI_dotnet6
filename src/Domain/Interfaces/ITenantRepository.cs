using Domain.Entities;

namespace Domain.Interfaces;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> GetTenantsAsync(bool trackChanges);
    Task<Tenant> GetTenantByIdAsync(int tenantId, bool trackChanges);
    Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateTenant(Tenant tenant);
    void DeleteTenant(Tenant tenant);
}
