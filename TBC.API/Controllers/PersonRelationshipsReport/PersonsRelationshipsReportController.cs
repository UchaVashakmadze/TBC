using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TBC.API.Controllers.PersonRelationshipsReport
{
    /// <summary>
    /// Persons Relationships Report Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public partial class PersonsRelationshipsReportController
    {
        /// <summary>
        /// Global variables
        /// </summary>
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonsRelationshipsReportController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

    }
}
