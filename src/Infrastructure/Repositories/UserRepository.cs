using Domain.RequestFeatures;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<User>> GetUsersAsync(UserParameters UserParameters, bool trackChanges) =>
    await FindAll(trackChanges)
        .Search(UserParameters.SearchTerm)
        .Sort(UserParameters.OrderBy)
        .ToListAsync();

    public async Task<User?> GetUserByIdAsync(string userId, bool trackChanges) =>
        await FindByCondition(t => t.Id.Equals(userId), trackChanges).SingleOrDefaultAsync();

    public async Task<IEnumerable<User>> GetUsersByIdsAsync(IEnumerable<string> userIds, 
        UserParameters UserParameters, bool trackChanges) =>
        await FindByCondition(r => userIds.Contains(r.Id), trackChanges)
        .Search(UserParameters.SearchTerm)
        .Sort(UserParameters.OrderBy)
        .ToListAsync();

    public void CreateUser(User user) => base.Create(user);

    public void DeleteUser(User user) => base.Delete(user);

}
