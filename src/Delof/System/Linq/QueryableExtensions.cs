using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> match)
            => condition ? query.Where(match) : query;

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, int, bool>> match)
            => condition ? query.Where(match) : query;

        public static TQueryable WhereIf<T, TQueryable>(this TQueryable query, bool condition, Expression<Func<T, int, bool>> match)
            where TQueryable : IQueryable<T>
        {
            return condition ? (TQueryable)query.Where(match) : query;
        }

        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skip, int limit)
        {
            return query.Skip(skip).Take(limit);
        }

        public static TQueryable PageBy<T, TQueryable>(this TQueryable query, int skip, int limit)
            where TQueryable : IQueryable<T>
        {
            return (TQueryable)query.Skip(skip).Take(limit);
        }
    }
}
