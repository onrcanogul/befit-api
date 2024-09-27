using System.Linq.Expressions;

namespace BeFit.Persistence.Extensions;

public static class QueryableExtension
{
    public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
    {
        if (condition)
            return source.Where(predicate);
        else
            return source;
    }
}