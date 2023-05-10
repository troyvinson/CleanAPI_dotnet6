using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IRoleTypeRepository
{
    Task<IEnumerable<RoleType>> GetRoleTypesAsync(bool trackChanges);
    Task<RoleType?> GetRoleTypeByIdAsync(int roleId, bool trackChanges);
    void CreateRoleType(RoleType roleType);
    void DeleteRoleType(RoleType roleType);
}
