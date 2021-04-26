using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList;

namespace TBC.API.Controllers.PersonRelationshipsReport
{
    public partial class PersonsRelationshipsReportController
    {
        /// <summary>
        /// Get Person Relationship Report
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetPersonRelationshipReport))]
        public async Task<IEnumerable<PersonRelationshipModel>> GetPersonRelationshipReport([FromQuery] GetPersonPersonRelationshipsModel query, CancellationToken cancellationToken) =>
            await _mediator.Send(_mapper.Map<GetPersonPersonRelationshipsQuery>(query), cancellationToken);
    }
}
