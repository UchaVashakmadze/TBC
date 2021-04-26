using AutoMapper;
using TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType;
using TBC.Application.Features.RelationshipType.Queries.GetRelationshipTypes;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.API.Controllers.RelationshipType.Mapper
{
    /// <summary>
    /// Relationship Type Mapper
    /// </summary>
    public class RelationshipTypeMapper : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RelationshipTypeMapper()
        {
            CreateMap<CreateRelationshipTypeModel, CreateRelationshipTypeCommand>();
            CreateMap<GetRelationshipTypesModel, GetRelationshipTypesQuery>();
            CreateMap<PersonsRelationshipType, RelationshipTypeModel>();
        }
    }
}
