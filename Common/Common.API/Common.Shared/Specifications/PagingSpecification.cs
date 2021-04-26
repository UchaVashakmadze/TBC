using System.Linq;

namespace Common.Shared.Specifications
{
    public static class PagingSpecification
    {
        public static IQueryable<T> GetPagedQuery<T>(IQueryable<T> query, int? pageNumber, int? pageSize)
        {
            pageSize ??= 10;
            pageNumber = (pageNumber != null && pageNumber > 0) ? pageNumber.Value : 1;
            var skip = (pageNumber.Value - 1) * pageSize;
            query = query.Skip(skip.Value).Take(pageSize.Value);
            return query;
        }
    }
}
