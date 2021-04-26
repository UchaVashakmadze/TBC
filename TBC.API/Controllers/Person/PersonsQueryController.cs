using System.Threading;
using System.Threading.Tasks;
using Common.Shared.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBC.Application.Features.Persons.Queries.GetPersonDetails;
using TBC.Application.Features.Persons.Queries.GetPersonsList;

namespace TBC.API.Controllers.Person
{
    public partial class PersonsController
    {
        /// <summary>
        /// Get Persons List
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetPersons))]
        public async Task<PagedList<PersonModel>> GetPersons([FromQuery] GetPersonsModel query, CancellationToken cancellationToken) =>
            await _mediator.Send(_mapper.Map<GetPersonsQuery>(query), cancellationToken);

        /// <summary>
        /// Get Person By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}", Name = nameof(GetPersonById))]
        public async Task<PersonDetailsModel> GetPersonById([FromRoute] int id, CancellationToken cancellationToken) =>
            await _mediator.Send(new GetPersonDetailsQuery{Id = id}, cancellationToken);
    }
}
