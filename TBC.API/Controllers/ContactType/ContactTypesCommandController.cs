using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.ContactType.Commands.CreateContactType;
using TBC.Application.Features.ContactType.Commands.DeleteContactType;
using TBC.Application.Features.ContactType.Commands.UpdateContactType;

namespace TBC.API.Controllers.ContactType
{
    public partial class ContactTypesController
    {
        /// <summary>
        /// Create Contact Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreateContactType))]
        public async Task<int> CreateContactType([FromBody] CreateContactTypeModel request) =>
            await _mediator.Send(_mapper.Map<CreateContactTypeCommand>(request));

        /// <summary>
        /// Update Contact Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdateContactType))]
        public async Task<Unit> UpdateContactType([FromRoute] int id, [FromBody] UpdateContactTypeModel request) =>
            await _mediator.Send(new UpdateContactTypeCommand { Id = id, Name = request.Name });

        /// <summary>
        /// Delete Contact Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeleteContactType))]
        public async Task<Unit> DeleteContactType([FromRoute] int id) =>
            await _mediator.Send(new DeleteContactTypeCommand { Id = id });
    }
}
