using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
{
    public TenantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Tenant>> GetTenantsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(t => t.Name)
        .ToListAsync();

    public async Task<Tenant?> GetTenantByIdAsync(int tenantId, bool trackChanges) =>
        await FindByCondition(t => t.Id.Equals(tenantId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<int> tenantIds, bool trackChanges) =>
        await FindByCondition(r => tenantIds.Contains(r.Id), trackChanges)
        .ToListAsync();

    public void CreateTenant(Tenant tenant) => base.Create(tenant);

    public void DeleteTenant(Tenant tenant) => base.Delete(tenant);

}
