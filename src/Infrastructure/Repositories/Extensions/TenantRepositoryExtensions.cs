using System.Linq.Dynamic.Core;

namespace Infrastructure.Repositories.Extensions;

public static class TenantRepositoryExtensions
{
    /// <summary>
    /// Searches the tenants by name.
    /// </summary>
    /// <param name="tenants"></param>
    /// <param name="searchTerm"></param>
    /// <returns>A list of tenants matching the search term</returns>
    public static IQueryable<Tenant> Search(this IQueryable<Tenant> tenants, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return tenants;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return tenants.Where(e =>
            e.Name!.ToLower().Contains(lowerCaseTerm));
    }

    /// <summary>
    /// Sorts the tenants by the URL "orderBy" query parameter instruction or by name if invalid or empty.
    /// </summary>
    /// <param name="tenants"></param>
    /// <param name="orderByQueryString"></param>
    /// <returns>A list of tenants ordered by the URL "orderBy" query parameter instruction</returns>
    public static IQueryable<Tenant> Sort(this IQueryable<Tenant> tenants, string? orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return tenants.OrderBy(e => e.Id);

        var orderQuery = OrderByQueryBuilder.CreateOrderQuery<Tenant>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return tenants.OrderBy(e => e.Id);

        return tenants.OrderBy(orderQuery);
    }

}