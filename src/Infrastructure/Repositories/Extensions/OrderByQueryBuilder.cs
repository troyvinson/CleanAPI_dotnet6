using System.Reflection;
using System.Text;

namespace Infrastructure.Repositories.Extensions;

public static class OrderByQueryBuilder
{
    /// <summary>
    /// Accepts the URL "orderBy" query string parameter and returns a string that can be used to sort the data.
    /// Can accept multiple properties separated by ',' and can accept a direction of "desc" for descending.
    /// Also accepts a property path separated by '.' to sort by a child property.
    /// </summary>
    /// <example>
    /// <code>orderBy=name</code>
    /// <code>orderBy=name,age</code>
    /// <code>orderBy=name,age desc</code>
    /// <code>orderBy=childProperty.name</code>
    /// </example>
    /// <typeparam name="T"></typeparam>
    /// <param name="orderByQueryString"></param>
    /// <returns>A formatted orderByQueryBuilder string</returns>
    public static string CreateOrderQuery<T>(string orderByQueryString)
    {
        var orderParams = orderByQueryString.Trim().Split(',');
        var orderByQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var direction = param.EndsWith(" desc") ? "descending" : "ascending";

            // The property path could contain multiple levels separated by '.'
            var propertyPath = propertyFromQueryName.Split('.');
            var property = typeof(T);
            PropertyInfo? objectProperty = null;

            // Loop through the property path to find the final property
            foreach (var (propName, objects) in
                from propName in propertyPath
                    // Get the properties of the current property type
                let objects = property.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                ?? Array.Empty<PropertyInfo>()
                where objects.Length > 0
                select (propName, objects))
            {
                // Make sure the requested property exists in the current property type
                objectProperty = objects.FirstOrDefault(p =>
                                    p.Name.Equals(propName, StringComparison.OrdinalIgnoreCase));

                if (objectProperty == null)
                    break;

                // Set the property to the property type of the current property in the path
                property = objectProperty.PropertyType;
            }

            if (objectProperty == null)
                continue;

            orderByQueryBuilder.Append($"{propertyFromQueryName} {direction}, ");
        }

        var orderQuery = orderByQueryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}
