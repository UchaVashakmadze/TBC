using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes;

namespace TBC.API.Controllers.RelationshipType
{
    public partial class RelationshipTypesController
    {
        /// <summary>
        /// Get Relationship Types
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetRelationshipTypes))]
        public async Task<PagedList<RelationshipTypeModel>> GetRelationshipTypes([FromQuery] GetRelationshipTypesModel query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(_mapper.Map<GetRelationshipTypesQuery>(query), cancellationToken);
        }
    }
}
