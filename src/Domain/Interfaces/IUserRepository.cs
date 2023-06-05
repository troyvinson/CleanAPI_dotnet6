using Domain.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(UserParameters UserParameters, bool trackChanges);
    Task<User?> GetUserByIdAsync(string userId, bool trackChanges);
    Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<string> ids, UserParameters UserParameters, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}
