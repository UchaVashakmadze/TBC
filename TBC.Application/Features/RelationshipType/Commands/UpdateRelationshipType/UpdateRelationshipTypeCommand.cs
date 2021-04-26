using MediatR;

namespace TBC.Application.Features.RelationshipType.Commands.UpdateRelationshipType
{
    public class UpdateRelationshipTypeCommand : IRequest
    {
        public int Id  { get; set; }
        public string Name { get; set; }
    }
}
