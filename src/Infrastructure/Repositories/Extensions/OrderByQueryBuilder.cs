using System.Reflection;
using System.Text;

namespace Infrastructure.Repositories.Extensions;

public static class OrderByQueryBuilder
{
    /// <summary>
    /// Accepts the URL "orderBy" query string parameter and returns a string that can be used to sort the data.
    /// </summary>
    /// <example>
    /// <code>orderBy=name</code>
    /// <code>orderBy=name,age</code>
    /// <code>orderBy=name,age desc</code>
    /// </example>
    /// <typeparam name="T"></typeparam>
    /// <param name="orderByQueryString"></param>
    /// <returns>A formatted orderByQueryBuilder string</returns>
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderByQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";

            orderByQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
        }

        var orderQuery = orderByQueryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}
