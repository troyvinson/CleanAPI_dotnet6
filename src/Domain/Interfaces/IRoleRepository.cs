using Domain.Entities;

namespace Domain.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetRolesAsync(bool trackChanges);
    Task<Role> GetRoleByIdAsync(int roleId, bool trackChanges);
    Task<IEnumerable<Role>> GetRolesByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateRole(Role role);
    void DeleteRole(Role role);
}
