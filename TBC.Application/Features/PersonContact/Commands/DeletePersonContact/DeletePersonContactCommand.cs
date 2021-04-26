using MediatR;

namespace TBC.Application.Features.PersonContact.Commands.DeletePersonContact
{
    public class DeletePersonContactCommand : IRequest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
