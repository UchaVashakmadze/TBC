using AutoMapper;
using TBC.Application.Features.City.Commands.CreateCity;
using TBC.Application.Features.City.Queries.GetCities;

namespace TBC.API.Controllers.City.Mapper
{
    /// <summary>
    /// Cities Mapper
    /// </summary>
    public class CitiesMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CitiesMapper()
        {
            CreateMap<CreateCityModel, CreateCityCommand>();
            CreateMap<GetCitiesModel, GetCitiesQuery>();
            CreateMap<Domain.AggregatesModel.CityAggregate.City, CityModel>();
        }
    }
}
