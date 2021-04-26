using MediatR;

namespace TBC.Application.Features.PersonRelationship.CreatePersonRelationship
{
    public class CreatePersonRelationshipCommand : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int PersonsRelationshipTypeId { get; set; }
    }
}
