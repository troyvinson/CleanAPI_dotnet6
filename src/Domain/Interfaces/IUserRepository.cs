using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(bool trackChanges);
    Task<User?> GetUserByIdAsync(Guid userId, bool trackChanges);
    Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}
