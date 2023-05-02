using System.Linq.Dynamic.Core;
using Domain.Entities;

namespace Infrastructure.Repositories.Extensions;

public static class EmployeeRepositoryExtensions
{
    /// <summary>
    /// Filters the employees by age.
    /// </summary>
    /// <param name="employees"></param>
    /// <param name="minAge"></param>
    /// <param name="maxAge"></param>
    /// <returns>A list of employees in the range of min and max age</returns>
    public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge)
    {
        return employees.Where(e => (e.Age >= minAge && e.Age <= maxAge));
    }

    /// <summary>
    /// Searches the employees by name.
    /// </summary>
    /// <param name="employees"></param>
    /// <param name="searchTerm"></param>
    /// <returns>A list of employees matching the search term</returns>
    public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return employees; 

        var lowerCaseTerm = searchTerm.Trim().ToLower(); 

        return employees.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
    }

    /// <summary>
    /// Sorts the employees by the URL "orderBy" query parameter instruction or by name if invalid or empty.
    /// </summary>
    /// <param name="employees"></param>
    /// <param name="orderByQueryString"></param>
    /// <returns>A list of employees ordered by the URL "orderBy" query parameter instruction</returns>
    public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return employees.OrderBy(e => e.Id);

        var orderQuery = OrderByQueryBuilder.CreateOrderQuery<Employee>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return employees.OrderBy(e => e.Name);

        return employees.OrderBy(orderQuery);
    }

}