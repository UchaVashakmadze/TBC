using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TBC.API.Controllers.Person
{
    /// <summary>
    /// Persons Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public partial class PersonsController
    {
        /// <summary>
        /// Global variables
        /// </summary>
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        public PersonsController(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

    }
}
