using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface ITenantRepository
{
    Task<IEnumerable<Tenant>> GetAllTenantsAsync(bool trackChanges);
    Task<Tenant?> GetTenantByIdAsync(int tenantId, bool trackChanges);
    Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateTenant(Tenant tenant);
    void DeleteTenant(Tenant tenant);
}
