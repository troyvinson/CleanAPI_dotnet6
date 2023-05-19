using System.Linq.Dynamic.Core;

namespace Infrastructure.Repositories.Extensions;

public static class UserRepositoryExtensions
{
    /// <summary>
    /// Searches the users by name.
    /// </summary>
    /// <param name="users"></param>
    /// <param name="searchTerm"></param>
    /// <returns>A list of users matching the search term</returns>
    public static IQueryable<User> Search(this IQueryable<User> users, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return users;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return users.Where(e =>
            e.UserName.ToLower().Contains(lowerCaseTerm) ||
            e.NormalizedUserName.ToLower().Contains(lowerCaseTerm) ||
            e.GivenName.ToLower().Contains(lowerCaseTerm) ||
            e.Surname.ToLower().Contains(lowerCaseTerm) ||
            e.NormalizedName.ToLower().Contains(lowerCaseTerm) ||
            e.Email.ToLower().Contains(lowerCaseTerm) ||
            e.NormalizedEmail.ToLower().Contains(lowerCaseTerm));
    }

    /// <summary>
    /// Sorts the users by the URL "orderBy" query parameter instruction or by name if invalid or empty.
    /// </summary>
    /// <param name="users"></param>
    /// <param name="orderByQueryString"></param>
    /// <returns>A list of users ordered by the URL "orderBy" query parameter instruction</returns>
    public static IQueryable<User> Sort(this IQueryable<User> users, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return users.OrderBy(e => e.Id);

        var orderQuery = OrderByQueryBuilder.CreateOrderQuery<User>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return users.OrderBy(e => e.Id);

        return users.OrderBy(orderQuery);
    }

}