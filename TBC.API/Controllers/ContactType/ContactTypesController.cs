using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TBC.API.Controllers.ContactType
{
    /// <summary>
    /// Contact Types Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public partial class ContactTypesController
    {
        /// <summary>
        /// Global variables
        /// </summary>
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactTypesController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

    }
}
