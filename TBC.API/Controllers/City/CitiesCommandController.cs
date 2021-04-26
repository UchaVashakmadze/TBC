using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.City.Commands.CreateCity;
using TBC.Application.Features.City.Commands.DeleteCity;
using TBC.Application.Features.City.Commands.UpdateCity;

namespace TBC.API.Controllers.City
{
    public partial class CitiesController
    {
        /// <summary>
        /// Create City
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreateCity))]
        public async Task<int> CreateCity([FromBody] CreateCityModel request) =>
            await _mediator.Send(_mapper.Map<CreateCityCommand>(request));

        /// <summary>
        /// Update City
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdateCity))]
        public async Task<Unit> UpdateCity([FromRoute] int id, [FromBody] UpdateCityModel request) =>
            await _mediator.Send(new UpdateCityCommand { Id = id, Name = request.Name });

        /// <summary>
        /// Delete City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeleteCity))]
        public async Task<Unit> DeleteCity([FromRoute] int id) =>
            await _mediator.Send(new DeleteCityCommand { Id = id});
    }
}
