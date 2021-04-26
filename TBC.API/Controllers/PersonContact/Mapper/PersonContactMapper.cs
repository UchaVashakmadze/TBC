using AutoMapper;
using TBC.Application.Features.PersonContact.Commands.CreatePersonContact;
using TBC.Application.Features.PersonContact.Commands.UpdatePersonContact;

namespace TBC.API.Controllers.PersonContact.Mapper
{
    /// <summary>
    /// Person Contact Mapper
    /// </summary>
    public class PersonContactMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonContactMapper()
        {
            CreateMap<CreatePersonContactModel, CreatePersonContactCommand>();
            CreateMap<UpdatePersonContactModel, UpdatePersonContactCommand>();
        }
    }
}
