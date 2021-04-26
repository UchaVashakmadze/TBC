using MediatR;

namespace TBC.Application.Features.PersonContact.Commands.UpdatePersonContact
{
    public class UpdatePersonContactCommand : IRequest
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int PersonContactTypeId { get; set; }
        public string Value { get; set; }
    }
}
