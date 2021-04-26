using Common.Shared.Base;
using MediatR;

namespace TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes
{
    public class GetRelationshipTypesQuery : IBaseListQuery, IRequest<PagedList<RelationshipTypeModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
    }
}
