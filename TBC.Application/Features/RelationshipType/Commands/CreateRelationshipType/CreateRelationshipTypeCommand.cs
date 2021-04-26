using MediatR;

namespace TBC.Application.Features.RelationshipType.Commands.CreateRelationshipType
{
    public class CreateRelationshipTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
