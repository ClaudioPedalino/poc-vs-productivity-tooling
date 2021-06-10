using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace poc_vs_tooling.Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool should, Expression<Func<T, bool>> expression)
            => should
                ? query.Where(expression)
                : query;
    }
}
