using Domain.Entities;

namespace Domain.Interfaces;

internal interface IUserRoleRepository 
{
    Task<IEnumerable<Company>> GetAllUserRolesAsync(bool trackChanges);
    Task<Company?> GetUserRoleByIdAsync(int roleId, bool trackChanges);
    void CreateUserRole(UserRole role);
    void DeleteUserRole(UserRole role);

}

