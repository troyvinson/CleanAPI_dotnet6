using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class MemberRoleRepository : RepositoryBase<MemberRole>, IMemberRoleRepository
{
    public MemberRoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<MemberRole>> GetMemberRolesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
        .OrderBy(u => u.Role!.RoleType!.Name == "MemberRole")
        .ToListAsync();
    }

    public void CreateMemberRole(MemberRole MemberRole) => base.Create(MemberRole);

    public void DeleteMemberRole(MemberRole MemberRole) => base.Delete(MemberRole);

}
