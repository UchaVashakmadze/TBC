using MediatR;

namespace TBC.Application.Features.PersonRelationship.DeletePersonRelationship
{
    public class DeletePersonRelationshipCommand : IRequest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
