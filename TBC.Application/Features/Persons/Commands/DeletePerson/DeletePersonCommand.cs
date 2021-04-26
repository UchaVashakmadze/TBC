using MediatR;

namespace TBC.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
