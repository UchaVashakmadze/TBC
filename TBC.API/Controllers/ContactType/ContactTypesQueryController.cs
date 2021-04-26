using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.ContactType.Queries.GetContactTypes;

namespace TBC.API.Controllers.ContactType
{
    public partial class ContactTypesController
    {
        /// <summary>
        /// Get Contact Types
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetContactTypes))]
        public async Task<PagedList<ContactTypeModel>> GetContactTypes([FromQuery] GetContactTypesModel query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(_mapper.Map<GetContactTypesQuery>(query), cancellationToken);
        }
    }
}
