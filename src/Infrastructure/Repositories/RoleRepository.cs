using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateRole(Role role) => base.Create(role);

    public void DeleteRole(Role role) => base.Delete(role);

    public async Task<IEnumerable<Role>> GetRolesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToListAsync();

    public async Task<Role?> GetRoleByIdAsync(int roleId, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(roleId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<Role>> GetRolesByIdsAsync(IEnumerable<int> roleIds, bool trackChanges) =>
        await FindByCondition(r => roleIds.Contains(r.Id), trackChanges)
        .ToListAsync();
}
