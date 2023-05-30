using Domain.RequestFeatures;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
{
    public TenantRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Tenant>> GetTenantsAsync(TenantParameters tenantParameters, bool trackChanges) =>
    await FindAll(trackChanges)
        .Search(tenantParameters.SearchTerm)
        .Sort(tenantParameters.OrderBy)
        .ToListAsync();

    public async Task<Tenant?> GetTenantByIdAsync(Guid tenantId, bool trackChanges) =>
        await FindByCondition(t => t.Id.Equals(tenantId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<Tenant>> GetTenantsByIdsAsync(IEnumerable<Guid> tenantIds, 
        TenantParameters tenantParameters, bool trackChanges) =>
        await FindByCondition(r => tenantIds.Contains(r.Id), trackChanges)
        .Search(tenantParameters.SearchTerm)
        .Sort(tenantParameters.OrderBy)
        .ToListAsync();

    public void CreateTenant(Tenant tenant) => base.Create(tenant);

    public void DeleteTenant(Tenant tenant) => base.Delete(tenant);

}
