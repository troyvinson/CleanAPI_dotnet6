using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

/// <summary>
/// Generic repository base class to provide CRUD operations for other repositories.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
        => RepositoryContext = repositoryContext;

    // Create
    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

    // Read
    // FindAll and FindByCondition provide option to track changes.
    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
          RepositoryContext.Set<T>().AsNoTracking() :
          RepositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        return !trackChanges ?
          RepositoryContext.Set<T>().Where(expression).AsNoTracking() :
          RepositoryContext.Set<T>().Where(expression);
    }

    // Update
    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    // Delete
    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}
