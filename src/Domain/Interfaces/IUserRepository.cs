using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IUserRepository 
{
    Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
    Task<User?> GetUserByIdAsync(int userId, bool trackChanges);
    Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}
