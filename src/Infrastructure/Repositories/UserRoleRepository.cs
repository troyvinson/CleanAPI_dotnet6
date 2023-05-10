using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<UserRole>> GetUserRolesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(u => u.Role!.RoleType!.Name == "UserRole")
        .ToListAsync();

    public void CreateUserRole(UserRole userRole) => base.Create(userRole);

    public void DeleteUserRole(UserRole userRole) => base.Delete(userRole);

}
