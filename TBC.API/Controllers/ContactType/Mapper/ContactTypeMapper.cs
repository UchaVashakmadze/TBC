using AutoMapper;
using TBC.Application.Features.ContactType.Commands.CreateContactType;
using TBC.Application.Features.ContactType.Queries.GetContactTypes;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;

namespace TBC.API.Controllers.ContactType.Mapper
{
    /// <summary>
    /// Contact Type Mapper
    /// </summary>
    public class ContactTypeMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ContactTypeMapper()
        {
            CreateMap<CreateContactTypeModel, CreateContactTypeCommand>();
            CreateMap<GetContactTypesModel, GetContactTypesQuery>();
            CreateMap<PersonContactType, ContactTypeModel>();
        }
    }
}
