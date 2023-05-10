using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IUserRoleRepository 
{
    Task<IEnumerable<UserRole>> GetUserRolesAsync(bool trackChanges);
    void CreateUserRole(UserRole userRole);
    void DeleteUserRole(UserRole userRole);
}
