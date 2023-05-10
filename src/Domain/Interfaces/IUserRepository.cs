using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(bool trackChanges);
    Task<User> GetUserByIdAsync(int userId, bool trackChanges);
    Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}
