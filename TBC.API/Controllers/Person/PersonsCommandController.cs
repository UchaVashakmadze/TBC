using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.Persons.Commands.CreatePerson;
using TBC.Application.Features.Persons.Commands.DeletePerson;
using TBC.Application.Features.Persons.Commands.UpdatePerson;

namespace TBC.API.Controllers.Person
{
    public partial class PersonsController
    {
        /// <summary>
        /// Create Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreatePerson))]
        public async Task<int> CreatePerson([FromQuery] CreatePersonModel request) =>
            await _mediator.Send(_mapper.Map<CreatePersonCommand>(request));

        /// <summary>
        /// Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdatePerson))]
        public async Task<Unit> UpdatePerson([FromRoute] int id, [FromQuery] UpdatePersonModel request)
        {
            var command = _mapper.Map<UpdatePersonCommand>(request);
            command.Id = id;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeletePerson))]
        public async Task<Unit> DeletePerson([FromRoute] int id) =>
            await _mediator.Send(new DeletePersonCommand { Id = id });
    }
}
