using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class RoleTypeRepository : RepositoryBase<RoleType>, IRoleTypeRepository
{
    public RoleTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public void CreateRoleType(RoleType roleType) => base.Create(roleType);

    public void DeleteRoleType(RoleType roleType) => base.Delete(roleType);

    public async Task<IEnumerable<RoleType>> GetRoleTypesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToListAsync();

    public async Task<RoleType?> GetRoleTypeByIdAsync(int roleTypeId, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(roleTypeId), trackChanges).SingleOrDefaultAsync();

}
