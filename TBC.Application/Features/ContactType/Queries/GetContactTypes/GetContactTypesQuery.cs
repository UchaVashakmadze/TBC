using Common.Shared.Base;
using MediatR;

namespace TBC.Application.Features.ContactType.Queries.GetContactTypes
{
    public class GetContactTypesQuery : IBaseListQuery, IRequest<PagedList<ContactTypeModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
    }
}
