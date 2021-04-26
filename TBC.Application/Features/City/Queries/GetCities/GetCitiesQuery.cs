using Common.Shared.Base;
using MediatR;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class GetCitiesQuery: IBaseListQuery, IRequest<PagedList<CityModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string SearchQuery { get; set; }
    }
}
