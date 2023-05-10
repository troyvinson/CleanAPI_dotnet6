﻿using System.Linq.Dynamic.Core;
using Domain.Entities;

namespace Infrastructure.Repositories.Extensions;

public static class MemberRepositoryExtensions
{
    /// <summary>
    /// Searches the members by name.
    /// </summary>
    /// <param name="members"></param>
    /// <param name="searchTerm"></param>
    /// <returns>A list of members matching the search term</returns>
    public static IQueryable<Member> Search(this IQueryable<Member> members, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return members; 

        var lowerCaseTerm = searchTerm.Trim().ToLower(); 

        return members.Where(e => e.User.Username.ToLower().Contains(lowerCaseTerm));
    }

    /// <summary>
    /// Sorts the members by the URL "orderBy" query parameter instruction or by name if invalid or empty.
    /// </summary>
    /// <param name="members"></param>
    /// <param name="orderByQueryString"></param>
    /// <returns>A list of members ordered by the URL "orderBy" query parameter instruction</returns>
    public static IQueryable<Member> Sort(this IQueryable<Member> members, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return members.OrderBy(e => e.Id);

        var orderQuery = OrderByQueryBuilder.CreateOrderQuery<Member>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return members.OrderBy(e => e.Id);

        return members.OrderBy(orderQuery);
    }

}