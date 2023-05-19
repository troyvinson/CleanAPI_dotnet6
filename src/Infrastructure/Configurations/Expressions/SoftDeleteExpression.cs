using System.Linq.Expressions;

namespace Infrastructure.Configurations.Expressions;

public static class SoftDeleteExpression
{
    public static LambdaExpression CreateFilterExpression(Type entityType)
    {
        var parameter = Expression.Parameter(entityType, "e");
        var property = Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted));
        var constant = Expression.Constant(false);
        var body = Expression.Equal(property, constant);
        var lambda = Expression.Lambda(body, parameter);

        return lambda;
    }
}

