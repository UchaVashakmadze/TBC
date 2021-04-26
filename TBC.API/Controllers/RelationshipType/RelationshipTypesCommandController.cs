using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType;
using TBC.Application.Features.RelationshipType.Commands.DeleteRelationshipType;
using TBC.Application.Features.RelationshipType.Commands.UpdateRelationshipType;

namespace TBC.API.Controllers.RelationshipType
{
    public partial class RelationshipTypesController
    {
        /// <summary>
        /// Create Relationship Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost(Name = nameof(CreateRelationshipType))]
        public async Task<int> CreateRelationshipType([FromBody] CreateRelationshipTypeModel request) =>
            await _mediator.Send(_mapper.Map<CreateRelationshipTypeCommand>(request));

        /// <summary>
        /// Update Relationship Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}", Name = nameof(UpdateRelationshipType))]
        public async Task<Unit> UpdateRelationshipType([FromRoute] int id, [FromBody] UpdateRelationshipTypeModel request) =>
            await _mediator.Send(new UpdateRelationshipTypeCommand { Id = id, Name = request.Name });

        /// <summary>
        /// Delete Relationship Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}", Name = nameof(DeleteRelationshipType))]
        public async Task<Unit> DeleteRelationshipType([FromRoute] int id) =>
            await _mediator.Send(new DeleteRelationshipTypeCommand { Id = id });
    }
}
