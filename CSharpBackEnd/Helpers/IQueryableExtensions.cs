using CSharpBackEnd.Models.Pagination;
using System.Linq;

namespace CSharpBackEnd.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
            PaginationDTO pagination)
        {
            return queryable.Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }
    }
}
