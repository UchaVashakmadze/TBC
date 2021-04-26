using MediatR;

namespace TBC.Application.Features.RelationshipType.Commands.DeleteRelationshipType
{
    public class DeleteRelationshipTypeCommand : IRequest
    {
        public int Id  { get; set; }
    }
}
