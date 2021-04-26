using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.PersonContact.Commands.CreatePersonContact;
using TBC.Application.Features.PersonContact.Commands.DeletePersonContact;
using TBC.Application.Features.PersonContact.Commands.UpdatePersonContact;

namespace TBC.API.Controllers.PersonContact
{
    public partial class PersonsContactsController
    {
        /// <summary>
        /// Create Person Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonContact))]
        public async Task<Unit> CreatePersonContact([FromBody] CreatePersonContactModel request) =>
            await _mediator.Send(_mapper.Map<CreatePersonContactCommand>(request));

        /// <summary>
        /// Update Person Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut(Name = nameof(UpdatePersonContact))]
        public async Task<Unit> UpdatePersonContact([FromBody] UpdatePersonContactModel request) =>
            await _mediator.Send(_mapper.Map<UpdatePersonContactCommand>(request));

        /// <summary>
        /// Delete Person Contact
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = nameof(DeletePersonContact))]
        public async Task<Unit> DeletePersonContact([FromQuery] DeletePersonContactCommand query) =>
            await _mediator.Send(query);

    }
}
