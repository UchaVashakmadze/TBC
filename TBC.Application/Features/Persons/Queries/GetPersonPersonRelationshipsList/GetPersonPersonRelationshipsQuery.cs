using System.Collections.Generic;
using MediatR;

namespace TBC.Application.Features.Persons.Queries.GetPersonPersonRelationshipsList
{
    public class GetPersonPersonRelationshipsQuery : IRequest<IEnumerable<PersonRelationshipModel>>
    {
        public int? PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
