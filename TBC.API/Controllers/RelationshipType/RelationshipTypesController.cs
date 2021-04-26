using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TBC.API.Controllers.RelationshipType
{
    /// <summary>
    /// Relationship Types Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public partial class RelationshipTypesController
    {
        /// <summary>
        /// Global variables
        /// </summary>
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public RelationshipTypesController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

    }
}
