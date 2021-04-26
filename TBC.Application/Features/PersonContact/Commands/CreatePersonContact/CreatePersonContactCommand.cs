using MediatR;

namespace TBC.Application.Features.PersonContact.Commands.CreatePersonContact
{
    public class CreatePersonContactCommand : IRequest
    {
        public int PersonId { get; set; }
        public int PersonContactTypeId { get; set; }
        public string Value { get; set; }
    }
}
