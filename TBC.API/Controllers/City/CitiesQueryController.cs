using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.City.Queries.GetCities;

namespace TBC.API.Controllers.City
{
    public partial class CitiesController
    {
        /// <summary>
        /// Get Cities
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetCities))]
        public async Task<PagedList<CityModel>> GetCities([FromQuery] GetCitiesModel query, CancellationToken cancellationToken) =>
            await _mediator.Send(_mapper.Map<GetCitiesQuery>(query), cancellationToken);
        
    }
}
