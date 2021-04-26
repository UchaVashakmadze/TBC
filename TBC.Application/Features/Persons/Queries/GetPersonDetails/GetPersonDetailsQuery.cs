using MediatR;

namespace TBC.Application.Features.Persons.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsModel>
    {
        public int Id { get; set; }
    }
}
