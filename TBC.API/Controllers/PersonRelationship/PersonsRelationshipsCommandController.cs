using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.PersonRelationship.CreatePersonRelationship;
using TBC.Application.Features.PersonRelationship.DeletePersonRelationship;

namespace TBC.API.Controllers.PersonRelationship
{
    public partial class PersonsRelationshipsController
    {
        /// <summary>
        /// Create Person Relationship
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonsRelationship))]
        public async Task<Unit> CreatePersonsRelationship([FromBody] CreatePersonRelationshipModel request) =>
            await _mediator.Send(_mapper.Map<CreatePersonRelationshipCommand>(request));


        /// <summary>
        /// Delete Person Relationship
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = nameof(DeletePersonsRelationship))]
        public async Task<Unit> DeletePersonsRelationship([FromQuery] DeletePersonRelationshipCommand query) =>
            await _mediator.Send(query);

    }
}
