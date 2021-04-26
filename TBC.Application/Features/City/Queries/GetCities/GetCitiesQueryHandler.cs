using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Shared.Base;
using MediatR;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, PagedList<CityModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<CityModel>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
        {
            var cities = _unitOfWork.CityRepository.GetAll(new CitySpecification(query).ToExpression());
            var pagedList = await PagedList<Domain.AggregatesModel.CityAggregate.City>.Create(_unitOfWork.CityRepository, cities, query.PageNumber, query.PageSize, _mapper, cancellationToken);
            return _mapper.Map<PagedList<CityModel>>(pagedList);
        }
    }
}
