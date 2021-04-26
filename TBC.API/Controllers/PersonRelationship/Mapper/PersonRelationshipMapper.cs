using AutoMapper;
using TBC.Application.Features.PersonRelationship.CreatePersonRelationship;

namespace TBC.API.Controllers.PersonRelationship.Mapper
{
    /// <summary>
    /// Person Relationship Mapper
    /// </summary>
    public class PersonRelationshipMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PersonRelationshipMapper()
        {
            CreateMap<CreatePersonRelationshipModel, CreatePersonRelationshipCommand>();
        }
    }
}
