using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(u => u.Username)
        .ToListAsync();

    public async Task<User?> GetUserByIdAsync(int userId, bool trackChanges) =>
        await FindByCondition(u => u.Id.Equals(userId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<int> ids, bool trackChanges) =>
        await FindByCondition(u => ids.Contains(u.Id), trackChanges)
        .ToListAsync();

    public void CreateUser(User user) => base.Create(user);

    public void DeleteUser(User user) => base.Delete(user);

}
